using Be.Windows.Forms;
using BrightIdeasSoftware;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static ioctlpus.Utilities.NativeMethods;
using static ioctlpus.Utilities.IOCTL;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using Microsoft.Win32;
namespace ioctlpus
{
    public partial class MainForm : Form
    {
        private List<Request> requests = new List<Request>();
        private Utilities.CRC16 CRC16 = new Utilities.CRC16();

        public MainForm()
        {
            InitializeComponent();

            // Add placeholder text to filters textbox.
            SendMessage(tbFilters.Handle, EM_SETCUEBANNER, 0, "Filters (e.g. 9C412000 br=64 !ec=C000000D)");

            // Setup HexBoxes.
            InitializeHexBox(hbInput, (int)nudInputSize.Value);
            InitializeHexBox(hbOutput, (int)nudOutputSize.Value);

            // Setup TreeListView.
            InitializeTreeListView();


            PopulateDevicesCombo(comboBox1); // replace with your ComboBox name

        }






        private const short MODE_MANUAL = 1;
        private const short MODE_AUTO = 2;

        private void SendHookRequestToDriver(string kernelDriverName /* e.g. "\\Device\\Spaceport" */)
        {
            if (string.IsNullOrWhiteSpace(kernelDriverName))
                throw new ArgumentException("Provide a kernel driver name like \"\\Device\\Foo\".", nameof(kernelDriverName));

            IntPtr pDriverName = IntPtr.Zero;
            IntPtr pReq = IntPtr.Zero;

            try
            {
                // unmanaged, NUL-terminated UTF-16
                pDriverName = Marshal.StringToHGlobalUni(kernelDriverName);

                var us = new UNICODE_STRING
                {
                    Length = checked((ushort)(kernelDriverName.Length * 2)),
                    MaximumLength = checked((ushort)((kernelDriverName.Length + 1) * 2)),
                    Buffer = pDriverName
                };

                var req = new HOOK_REQUEST
                {
                    driverName = us,
                    mode = MODE_AUTO,
                    fuzz = false,
                    _pad0 = 0,
                    type = 0,
                    _pad1 = 0,
                    address = IntPtr.Zero
                };

                // sanity: sizes should be 16 and 32 respectively
                // (remove these checks once verified)
                if (Marshal.SizeOf<UNICODE_STRING>() != 16 ||
                    Marshal.SizeOf<HOOK_REQUEST>() != 32)
                    throw new InvalidOperationException("Struct sizes do not match expected (UNICODE_STRING=16, HOOK_REQUEST=32).");

                int size = Marshal.SizeOf<HOOK_REQUEST>();
                pReq = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(req, pReq, false);

                using (var h = IoctlNative.CreateFile(
                    IoctlNative.USR_DEVICE_NAME,
                    IoctlNative.GENERIC_READ | IoctlNative.GENERIC_WRITE,
                    IoctlNative.FILE_SHARE_READ | IoctlNative.FILE_SHARE_WRITE,
                    IntPtr.Zero,
                    IoctlNative.OPEN_EXISTING,
                    0,
                    IntPtr.Zero))
                {
                    if (h.IsInvalid)
                    {
                        int err = Marshal.GetLastWin32Error();
                        throw new Win32Exception(err, $@"CreateFile({IoctlNative.USR_DEVICE_NAME}) failed (0x{err:X}).");
                    }

                    bool ok = IoctlNative.DeviceIoControl(
                        h,
                        IoctlNative.IOCTL_DUMP_METHOD_BUFFERED,
                        pReq, (uint)size,
                        IntPtr.Zero, 0,
                        out uint _, IntPtr.Zero);

                    if (!ok)
                    {
                        int err = Marshal.GetLastWin32Error();
                        throw new Win32Exception(err, $"DeviceIoControl failed (0x{err:X}).");
                    }
                }
            }
            finally
            {
                if (pReq != IntPtr.Zero) Marshal.FreeHGlobal(pReq);
                if (pDriverName != IntPtr.Zero) Marshal.FreeHGlobal(pDriverName);
            }
        }























































    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern uint QueryDosDevice(string lpDeviceName, char[] lpTargetPath, int ucchMax);

        private static List<string> EnumerateGlobalDosDevices()
        {
            int size = 16 * 1024;
            while (true)
            {
                var buffer = new char[size];
                uint chars = QueryDosDevice(null, buffer, buffer.Length);
                if (chars == 0)
                {
                    int err = Marshal.GetLastWin32Error();
                    const int ERROR_INSUFFICIENT_BUFFER = 122;
                    if (err == ERROR_INSUFFICIENT_BUFFER) { size *= 2; continue; }
                    throw new Win32Exception(err);
                }

                // MULTI_SZ → split on '\0' until double-terminator
                var list = new List<string>();
                int start = 0;
                for (int i = 0; i < chars; i++)
                {
                    if (buffer[i] == '\0')
                    {
                        if (i == start) break; // double NUL = end
                        list.Add(new string(buffer, start, i - start));
                        start = i + 1;
                    }
                }
                return list;
            }
        }

        private static string ToWin32DevicePath(string name)
        {
            // All entries can be opened via \\.\Name; drive letters already include a colon.
            return @"\\.\" + name;
        }

        private void PopulateDevicesCombo(ComboBox combo)
        {
            var names = EnumerateGlobalDosDevices();

            // Optional: filter out some noisy pseudo-names
            var filtered = names.Where(n =>
                !string.Equals(n, "GLOBALROOT", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(n, "UNC", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(n, "MSPipes", StringComparison.OrdinalIgnoreCase));

            var display = filtered
                .Select(ToWin32DevicePath)
                .OrderBy(s => s, StringComparer.OrdinalIgnoreCase)
                .ToArray();

            combo.BeginUpdate();
            combo.Items.Clear();
            combo.Items.AddRange(display);
            if (combo.Items.Count > 0) combo.SelectedIndex = 0;
            combo.EndUpdate();
        }


        /// <summary>
        /// Initialize the given buffer view.
        /// </summary>
        /// <param name="hexBox"></param>
        /// <param name="size"></param>
        private void InitializeHexBox(HexBox hexBox, int size)
        {
            hexBox.ColumnInfoVisible = true;
            hexBox.VScrollBarVisible = true;
            hexBox.LineInfoVisible = true;
            hexBox.StringViewVisible = true;
            DynamicByteProvider dbpData = new DynamicByteProvider(new byte[size]);
            hexBox.ByteProvider = dbpData;
        }

        /// <summary>
        /// Initialize the Request History views.
        /// </summary>
        private void InitializeTreeListView()
        {
            // Add colours to request rows.
            tlvRequestHistory.FormatRow += (sender, eventArgs) =>
            {
                Request transmission = (Request)eventArgs.Model;
                if (transmission.IsFavourite)
                    eventArgs.Item.BackColor = System.Drawing.Color.LightYellow;
                else if (transmission.ReturnValue > 0)
                    eventArgs.Item.BackColor = System.Drawing.Color.MistyRose;
            };

            // Rename requests when double-clicked or F2 is pressed.
            tlvRequestHistory.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;

            // How to identify if a row has children.
            tlvRequestHistory.CanExpandGetter = delegate (Object tx)
            {
                return ((Request)tx).Children.Count > 0;
            };

            // Where row children are located.
            tlvRequestHistory.ChildrenGetter = delegate (Object tx)
            {
                return ((Request)tx).Children;
            };

            // Populate HexBoxes when the selection changes.
            tlvRequestHistory.SelectionChanged += (sender, eventArgs) =>
            {
                if (tlvRequestHistory.SelectedIndex == -1) return;

                Request tx = (Request)tlvRequestHistory.SelectedObject;

                comboBox1.Text = tx.DevicePath;
                tbIOCTL.Text = tx.IOCTL.ToString("X");
                nudInputSize.Value = tx.PreCallInput.Length;
                nudOutputSize.Value = tx.PostCallOutput.Length;

                DynamicByteProvider dbpDataInput = new DynamicByteProvider(tx.PreCallInput);
                hbInput.ByteProvider = dbpDataInput;

                DynamicByteProvider dbpDataOutput = new DynamicByteProvider(tx.PostCallOutput);
                hbOutput.ByteProvider = dbpDataOutput;
            };
        }



        /// <summary>
        /// Validate that provided IOCTL is legitimate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbIOCTL_TextChanged(object sender, EventArgs e)
        {
            Point toolTipCoords = tbIOCTL.Location;
            toolTipCoords.X -= 89;
            toolTipCoords.Y -= 27;

            uint ioctl;
            if (!UInt32.TryParse(tbIOCTL.Text, System.Globalization.NumberStyles.HexNumber, null, out ioctl))
            {
                tbIOCTL.BackColor = System.Drawing.Color.MistyRose;
                btnSend.Enabled = false;
                toolTip.Show("IOCTL codes must be in hexadecimal format.", tbIOCTL, toolTipCoords, 3000);
            }
            else
            {
                tbIOCTL.BackColor = System.Drawing.Color.White;
                btnSend.Enabled = true;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SafeFileHandle sfh = CreateFile(
                comboBox1.SelectedItem.ToString(),
                (FileAccess)0x2000000,
                FileShare.ReadWrite,
                IntPtr.Zero,
                FileMode.Open,
                FileAttributes.Normal,
                IntPtr.Zero);

            uint returnedBytes = 0;
            uint inputSize = (uint)nudInputSize.Value;
            uint outputSize = (uint)nudOutputSize.Value;

            long hbInputLength = ((DynamicByteProvider)hbInput.ByteProvider).Length;
            byte[] inputBuffer = new byte[inputSize];
            MemSet(Marshal.UnsafeAddrOfPinnedArrayElement(inputBuffer, 0), 0, (int)hbInputLength);

            for (int i = 0; i < inputSize; i++)
                if (i < hbInputLength)
                    inputBuffer[i] = ((DynamicByteProvider)hbInput.ByteProvider).ReadByte(i);
                else
                    inputBuffer[i] = 0;

            long hbOutputLength = ((DynamicByteProvider)hbOutput.ByteProvider).Length;
            byte[] outputBuffer = new byte[outputSize];
            MemSet(Marshal.UnsafeAddrOfPinnedArrayElement(outputBuffer, 0), 0, (int)hbOutputLength);

            uint ioctl = Convert.ToUInt32(tbIOCTL.Text, 16);
            DeviceIoControl(sfh, ioctl, inputBuffer, inputSize, outputBuffer, outputSize, ref returnedBytes, IntPtr.Zero);
            int errorCode = Marshal.GetLastWin32Error();
            sfh.Close();

            DynamicByteProvider requestData = new DynamicByteProvider(inputBuffer);
            hbInput.ByteProvider = requestData;

            DynamicByteProvider responseData = new DynamicByteProvider(outputBuffer);
            hbOutput.ByteProvider = responseData;

            Request newTx = new Request();
            newTx.RequestName = String.Format(
                "0x{0:X} ({1:X4}-{2:D5})",
                ioctl,
                CRC16.ComputeChecksum(inputBuffer),
                (int)(DateTime.Now.Ticks % 1e11 / 1e6));
            newTx.DevicePath = comboBox1.SelectedItem.ToString();
            newTx.IOCTL = ioctl;
            newTx.PreCallInput = inputBuffer;
            newTx.PostCallOutput = outputBuffer;
            newTx.ReturnValue = errorCode;
            newTx.BytesReturned = returnedBytes;

            //if (tlvRequestHistory.SelectedObject == null)
            //{
            //    newTx.Parent = null;
            //    requests.Add(newTx);
            //}
            //else
            //{
            //    newTx.Parent = (Request)tlvRequestHistory.SelectedObject;

            //    if ((newTx.PreCallInput.SequenceEqual(newTx.Parent.PreCallInput)) && (newTx.Parent.Parent != null))
            //        newTx.Parent.Children.Add(newTx);
            //    else
            //        newTx.Children.Add(newTx);
            //}

            // Avoiding tree structure for now.
            newTx.Parent = null;
            requests.Add(newTx);

            tlvRequestHistory.HideSelection = false;
            tlvRequestHistory.SetObjects(requests);
            tlvRequestHistory.Expand(newTx.Parent);
            tlvRequestHistory.Sort(tlvRequestHistory.GetColumn(3), SortOrder.Descending);
            return;
        }

        /// <summary>
        /// Mark the selected request as a favourite.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStarRequest_Click(object sender, EventArgs e)
        {
            if (tlvRequestHistory.SelectedIndex == -1) return;
            ((Request)tlvRequestHistory.SelectedObject).IsFavourite ^= true;
            tlvRequestHistory.SetObjects(requests);
        }

        private void btnOpenDB_Click(object sender, EventArgs e)
        {
            // ToDo
        }

        /// <summary>
        /// Filters results in the Request History view (TODO).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbFilters_TextChanged(object sender, EventArgs e)
        {
            tlvRequestHistory.ModelFilter = null;
            tlvRequestHistory.ModelFilter = new ModelFilter(delegate (Object tx)
            {
                return ((Request)tx).RequestName.Contains(tbFilters.Text);
            });
        }

        /// <summary>
        /// Shows the About window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAbout_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["AboutForm"] as AboutForm == null)
            {
                AboutForm aboutForm = new AboutForm();
                aboutForm.Show();
            }
            else
            {
                AboutForm aboutForm = Application.OpenForms["AboutForm"] as AboutForm;
                aboutForm.Focus();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = "c:\\";
                ofd.Filter = "Data files (*.data)|*.data";
                ofd.FilterIndex = 0;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog(this) != DialogResult.OK)
                    return;

                string selectedFileName = ofd.FileName;

                try
                {
                    // Read raw bytes from the .data file
                    byte[] bytes = File.ReadAllBytes(selectedFileName);

                    // Push bytes into the HexBox
                    hbInput.ByteProvider = new DynamicByteProvider(bytes);

                    // Keep the input-size control in sync (so your send logic uses all bytes)
                    int len = bytes.Length;
                    if (len > (int)nudInputSize.Maximum) nudInputSize.Maximum = len;
                    if (len < (int)nudInputSize.Minimum) len = (int)nudInputSize.Minimum;
                    nudInputSize.Value = len;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this,
                        $"Failed to load data file:\n{ex.Message}",
                        "Load Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Open .conf";
                ofd.Filter = "Conf files (*.conf)|*.conf|All files (*.*)|*.*";
                ofd.FilterIndex = 0;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog(this) != DialogResult.OK)
                    return;
                try
                {

                    var lines = File.ReadAllLines(ofd.FileName, Encoding.Unicode);
                    for (var i = 0; i < lines.Length; i += 1)
                    {
                        var line = lines[i];
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        if (line.Contains("IOCTL"))
                        {
                            int colon = line.IndexOf(':');
                            if (colon >= 0)
                            {
                                string key = line.Substring(0, colon).Trim();
                                string val = line.Substring(colon + 1).Trim();
                                tbIOCTL.Text = val;
                            }
                        }
                        if (line.Contains("InputBufferLength"))
                        {
                            int colon = line.IndexOf(':');
                            if (colon >= 0)
                            {
                                string key = line.Substring(0, colon).Trim();
                                string val = line.Substring(colon + 1).Trim();
                                nudInputSize.Text = val;
                            }
                        }
                        if (line.Contains("OutputBufferLength"))
                        {
                            int colon = line.IndexOf(':');
                            if (colon >= 0)
                            {
                                string key = line.Substring(0, colon).Trim();
                                string val = line.Substring(colon + 1).Trim();
                                nudOutputSize.Text = val;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this,
                        $"Failed to load .conf file:\n{ex.Message}",
                        "Load Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }



            string device, func, access, method, err;
            if (!IoctlDecoder.TryDecode(tbIOCTL.Text, out device, out func, out access, out method, out err))
            {
                MessageBox.Show(this, err, "Decode IOCTL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            textBox1.Text = device;
            textBox2.Text = func;
            textBox3.Text = access;
            textBox4.Text = method;

        }

        private void nudOutputSize_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblOutputSize_Click(object sender, EventArgs e)
        {

        }

        private void nudInputSize_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblInputSize_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (IsValidDevicePath(comboBox1.SelectedItem.ToString()))
            {
                comboBox1.BackColor = System.Drawing.Color.Honeydew;
            }
            else
            {
                comboBox1.BackColor = System.Drawing.Color.MistyRose;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string hex = textBoxHex.Text.Trim();
            if (hex.StartsWith("0x", StringComparison.OrdinalIgnoreCase)) hex = hex.Substring(2);

            if (uint.TryParse(hex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out uint u))
                textBoxHex.Text = u.ToString();       // decimal string
            else
                MessageBox.Show("Not valid hex.");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxDec.Text, out int val))
                textBoxDec.Text = val.ToString("X");  // e.g., "12E0"
            else
                MessageBox.Show("Not a valid decimal number.");
        }


        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                string driverName = comboBox1.Text.Replace("\\\\.\\","\\Device\\");

                Cursor = Cursors.WaitCursor;
                SendHookRequestToDriver(driverName);
                Cursor = Cursors.Default;

                MessageBox.Show(this, $"Success.\nSent request for: {driverName}", "IOCTLDump Client",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(this, ex.Message, "IOCTLDump Client",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





















        public static class IoctlDecoder
        {
            // Device names indexed 1..54 (0 is unused here, like your JS)
            private static readonly string[] DeviceNames = new string[55];

            static IoctlDecoder()
            {
                DeviceNames[1] = "BEEP";
                DeviceNames[2] = "CD_ROM";
                DeviceNames[3] = "CD_ROM_FILE_SYSTEM";
                DeviceNames[4] = "CONTROLLER";
                DeviceNames[5] = "DATALINK";
                DeviceNames[6] = "DFS";
                DeviceNames[7] = "DISK";
                DeviceNames[8] = "DISK_FILE_SYSTEM";
                DeviceNames[9] = "FILE_SYSTEM";
                DeviceNames[10] = "INPORT_PORT";
                DeviceNames[11] = "KEYBOARD";
                DeviceNames[12] = "MAILSLOT";
                DeviceNames[13] = "MIDI_IN";
                DeviceNames[14] = "MIDI_OUT";
                DeviceNames[15] = "MOUSE";
                DeviceNames[16] = "MULTI_UNC_PROVIDER";
                DeviceNames[17] = "NAMED_PIPE";
                DeviceNames[18] = "NETWORK";
                DeviceNames[19] = "NETWORK_BROWSER";
                DeviceNames[20] = "NETWORK_FILE_SYSTEM";
                DeviceNames[21] = "NULL";
                DeviceNames[22] = "PARALLEL_PORT";
                DeviceNames[23] = "PHYSICAL_NETCARD";
                DeviceNames[24] = "PRINTER";
                DeviceNames[25] = "SCANNER";
                DeviceNames[26] = "SERIAL_MOUSE_PORT";
                DeviceNames[27] = "SERIAL_PORT";
                DeviceNames[28] = "SCREEN";
                DeviceNames[29] = "SOUND";
                DeviceNames[30] = "STREAMS";
                DeviceNames[31] = "TAPE";
                DeviceNames[32] = "TAPE_FILE_SYSTEM";
                DeviceNames[33] = "TRANSPORT";
                DeviceNames[34] = "UNKNOWN";
                DeviceNames[35] = "VIDEO";
                DeviceNames[36] = "VIRTUAL_DISK";
                DeviceNames[37] = "WAVE_IN";
                DeviceNames[38] = "WAVE_OUT";
                DeviceNames[39] = "8042_PORT";
                DeviceNames[40] = "NETWORK_REDIRECTOR";
                DeviceNames[41] = "BATTERY";
                DeviceNames[42] = "BUS_EXTENDER";
                DeviceNames[43] = "MODEM";
                DeviceNames[44] = "VDM";
                DeviceNames[45] = "MASS_STORAGE";
                DeviceNames[46] = "SMB";
                DeviceNames[47] = "KS";
                DeviceNames[48] = "CHANGER";
                DeviceNames[49] = "SMARTCARD";
                DeviceNames[50] = "ACPI";
                DeviceNames[51] = "DVD";
                DeviceNames[52] = "FULLSCREEN_VIDEO";
                DeviceNames[53] = "DFS_FILE_SYSTEM";
                DeviceNames[54] = "DFS_VOLUME";
            }

            public static bool TryDecode(
                string ioctlHex,
                out string deviceText,
                out string funcText,
                out string accessText,
                out string methodText,
                out string error)
            {
                deviceText = funcText = accessText = methodText = string.Empty;
                error = string.Empty;

                if (string.IsNullOrWhiteSpace(ioctlHex))
                {
                    error = "Empty IOCTL value.";
                    return false;
                }

                var s = ioctlHex.Trim();
                if (s.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                    s = s.Substring(2);

                uint input;
                if (!uint.TryParse(s, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out input))
                {
                    error = ioctlHex + " is not a valid hex IOCTL value.";
                    return false;
                }

                // Same bit-fields as in your JS:
                // DeviceType: bits 31..16 (12 bits used)
                // Access    : bits 15..14
                // Function  : bits 13..2  (12 bits)
                // Method    : bits 1..0
                uint deviceVal = (input >> 16) & 0xFFFu;
                uint funcVal = (input >> 2) & 0xFFFu;
                uint access = (input >> 14) & 0x3u;
                uint method = input & 0x3u;

                // Device text
                if (deviceVal <= 54 && deviceVal != 0 && !string.IsNullOrEmpty(DeviceNames[deviceVal]))
                    deviceText = string.Format("{0} (0x{1:X})", DeviceNames[deviceVal], deviceVal);
                else
                    deviceText = "0x" + deviceVal.ToString("X");

                // Function text (hex)
                funcText = "0x" + funcVal.ToString("X");

                // Access text
                switch (access)
                {
                    case 0: accessText = "FILE_ANY_ACCESS"; break;
                    case 1: accessText = "FILE_READ_ACCESS"; break;
                    case 2: accessText = "FILE_WRITE_ACCESS"; break;
                    case 3: accessText = "Read and Write"; break;
                    default: accessText = access.ToString(); break;
                }

                // Method text
                switch (method)
                {
                    case 0: methodText = "METHOD_BUFFERED"; break;
                    case 1: methodText = "METHOD_IN_DIRECT"; break;
                    case 2: methodText = "METHOD_OUT_DIRECT"; break; // fixed typo from JS
                    case 3: methodText = "METHOD_NEITHER"; break;
                    default: methodText = method.ToString(); break;
                }

                return true;
            }
        }


        internal static class DriverLoader
        {
            // Privilege constants
            private const string SE_LOAD_DRIVER_NAME = "SeLoadDriverPrivilege";
            private const int SE_PRIVILEGE_ENABLED = 0x00000002;
            private const int TOKEN_ADJUST_PRIVILEGES = 0x20;
            private const int TOKEN_QUERY = 0x08;

            private const string SERVICES_BASE = @"SYSTEM\CurrentControlSet\Services";

            // ntdll!NtLoadDriver
            [DllImport("ntdll.dll")]
            private static extern int NtLoadDriver(ref UNICODE_STRING DriverServiceName);

            // Win32 privilege APIs
            [DllImport("advapi32.dll", SetLastError = true)]
            private static extern bool OpenProcessToken(IntPtr ProcessHandle, int DesiredAccess, out SafeFileHandle TokenHandle);

            [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            private static extern bool LookupPrivilegeValue(string lpSystemName, string lpName, out LUID lpLuid);

            [DllImport("advapi32.dll", SetLastError = true)]
            private static extern bool AdjustTokenPrivileges(
                SafeFileHandle TokenHandle,
                bool DisableAllPrivileges,
                ref TOKEN_PRIVILEGES NewState,
                int BufferLength,
                IntPtr PreviousState,
                IntPtr ReturnLength);

            [DllImport("kernel32.dll")]
            private static extern IntPtr GetCurrentProcess();

            [StructLayout(LayoutKind.Sequential)]
            private struct LUID { public uint LowPart; public int HighPart; }

            [StructLayout(LayoutKind.Sequential)]
            private struct LUID_AND_ATTRIBUTES
            {
                public LUID Luid;
                public int Attributes;
            }

            [StructLayout(LayoutKind.Sequential)]
            private struct TOKEN_PRIVILEGES
            {
                public int PrivilegeCount; // 1
                public LUID_AND_ATTRIBUTES Privileges;
            }

            // UNICODE_STRING (x64)
            [StructLayout(LayoutKind.Sequential)]
            private struct UNICODE_STRING
            {
                public ushort Length;         // bytes (no NUL)
                public ushort MaximumLength;  // bytes (with NUL)
                public IntPtr Buffer;         // PWSTR
            }

            private static void RequirePrivilege(string privilegeName)
            {
                LUID luid;
                if (!LookupPrivilegeValue(null, privilegeName, out luid))
                    throw new Win32Exception(Marshal.GetLastWin32Error(), "LookupPrivilegeValue failed.");

                SafeFileHandle hToken;
                if (!OpenProcessToken(GetCurrentProcess(), TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, out hToken))
                    throw new Win32Exception(Marshal.GetLastWin32Error(), "OpenProcessToken failed.");

                using (hToken)
                {
                    var tp = new TOKEN_PRIVILEGES
                    {
                        PrivilegeCount = 1,
                        Privileges = new LUID_AND_ATTRIBUTES { Luid = luid, Attributes = SE_PRIVILEGE_ENABLED }
                    };

                    if (!AdjustTokenPrivileges(hToken, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero))
                        throw new Win32Exception(Marshal.GetLastWin32Error(), "AdjustTokenPrivileges failed.");

                    int err = Marshal.GetLastWin32Error();
                    if (err != 0)
                        throw new Win32Exception(err, "AdjustTokenPrivileges did not enable the privilege.");
                }
            }

            private static string CopyDriverToWindowsTemp(string sourcePath)
            {
                string windowsDir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                string dstPath = Path.Combine(windowsDir, "Temp", Path.GetFileName(sourcePath));
                string parent = Path.GetDirectoryName(dstPath);
                if (!string.IsNullOrEmpty(parent))
                    Directory.CreateDirectory(parent);
                File.Copy(sourcePath, dstPath, true);
                return dstPath;
            }

            /// <summary>
            /// Loads a kernel driver via NtLoadDriver; cleans up the service key and temp copy.
            /// Returns NTSTATUS (0 == success).
            /// </summary>
            public static int LoadDriver(string driverImageFullPath, string serviceName)
            {
                if (string.IsNullOrWhiteSpace(driverImageFullPath) || !File.Exists(driverImageFullPath))
                    throw new FileNotFoundException("Driver image not found.", driverImageFullPath);
                if (string.IsNullOrWhiteSpace(serviceName))
                    throw new ArgumentException("Service name is required.", "serviceName");

                string dstPath = CopyDriverToWindowsTemp(driverImageFullPath);

                RegistryKey createdKey = null;
                try
                {
                    RequirePrivilege(SE_LOAD_DRIVER_NAME);

                    string servicesKeyPath = SERVICES_BASE + "\\" + serviceName;

                    using (var existing = Registry.LocalMachine.OpenSubKey(servicesKeyPath))
                    {
                        if (existing != null)
                            throw new InvalidOperationException("Service key already exists: HKLM\\" + servicesKeyPath);
                    }

                    createdKey = Registry.LocalMachine.CreateSubKey(servicesKeyPath, true);
                    if (createdKey == null)
                        throw new InvalidOperationException("Failed to create service key.");

                    // Type = 1 (kernel driver), ErrorControl = 1, Start = 3 (demand)
                    createdKey.SetValue("Type", 1, RegistryValueKind.DWord);
                    createdKey.SetValue("ErrorControl", 1, RegistryValueKind.DWord);
                    createdKey.SetValue("Start", 3, RegistryValueKind.DWord);

                    // ImagePath relative to %WINDIR%
                    string windowsDir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                    if (!windowsDir.EndsWith("\\", StringComparison.Ordinal)) windowsDir += "\\";
                    string windowsRelative = dstPath.StartsWith(windowsDir, StringComparison.OrdinalIgnoreCase)
                        ? dstPath.Substring(windowsDir.Length)
                        : dstPath;
                    createdKey.SetValue("ImagePath", windowsRelative, RegistryValueKind.String);

                    // Build \Registry\Machine\System\CurrentControlSet\Services\<name>
                    string regPath = "\\Registry\\Machine\\System\\CurrentControlSet\\Services\\" + serviceName;

                    // UNICODE_STRING for NtLoadDriver
                    IntPtr pBuf = IntPtr.Zero;
                    try
                    {
                        pBuf = Marshal.StringToHGlobalUni(regPath);
                        var us = new UNICODE_STRING
                        {
                            Buffer = pBuf,
                            Length = (ushort)(regPath.Length * 2),
                            MaximumLength = (ushort)((regPath.Length + 1) * 2)
                        };

                        int status = NtLoadDriver(ref us);
                        return status;
                    }
                    finally
                    {
                        if (pBuf != IntPtr.Zero) Marshal.FreeHGlobal(pBuf);
                    }
                }
                finally
                {
                    // Cleanup like the C++ code
                    try
                    {
                        if (createdKey != null) createdKey.Dispose();
                    }
                    catch { }

                    try
                    {
                        using (var baseKey = Registry.LocalMachine.OpenSubKey(SERVICES_BASE, writable: true))
                        {
                            if (baseKey != null)
                            {
                                try { baseKey.DeleteSubKeyTree(serviceName); } catch { }
                            }
                        }
                    }
                    catch { }

                    try { if (File.Exists(dstPath)) File.Delete(dstPath); } catch { }
                }
            }
        }















        internal static class IoctlNative
        {
            // Win32 constants
            public const uint GENERIC_READ = 0x80000000;
            public const uint GENERIC_WRITE = 0x40000000;
            public const uint FILE_SHARE_READ = 0x00000001;
            public const uint FILE_SHARE_WRITE = 0x00000002;
            public const uint OPEN_EXISTING = 3;

            public const uint FILE_ANY_ACCESS = 0;
            public const uint METHOD_BUFFERED = 0;

            // Your header
            public const uint DUMP_TYPE = 40000;                 // 0x9C40
            public const string USR_DEVICE_NAME = @"\\.\dIoctl";

            // CTL_CODE ((DeviceType<<16) | (Access<<14) | (Function<<2) | Method)
            public static uint CTL_CODE(uint deviceType, uint function, uint method, uint access) =>
                (deviceType << 16) | (access << 14) | (function << 2) | method;

            public static readonly uint IOCTL_DUMP_METHOD_BUFFERED =
                CTL_CODE(DUMP_TYPE, 0x902, METHOD_BUFFERED, FILE_ANY_ACCESS);

            [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern SafeFileHandle CreateFile(
                string lpFileName,
                uint dwDesiredAccess,
                uint dwShareMode,
                IntPtr lpSecurityAttributes,
                uint dwCreationDisposition,
                uint dwFlagsAndAttributes,
                IntPtr hTemplateFile);

            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool DeviceIoControl(
                SafeFileHandle hDevice,
                uint dwIoControlCode,
                IntPtr lpInBuffer,
                uint nInBufferSize,
                IntPtr lpOutBuffer,
                uint nOutBufferSize,
                out uint lpBytesReturned,
                IntPtr lpOverlapped);
        }

        // UNICODE_STRING (x64: 16 bytes)
        [StructLayout(LayoutKind.Explicit, Size = 16)]
        internal struct UNICODE_STRING
        {
            [FieldOffset(0)] public ushort Length;         // bytes, excluding NUL
            [FieldOffset(2)] public ushort MaximumLength;  // bytes, including space for NUL
            [FieldOffset(8)] public IntPtr Buffer;         // PWSTR (8-byte aligned)
        }

        // HOOK_REQUEST (x64: 32 bytes, see offsets below)
        [StructLayout(LayoutKind.Explicit, Size = 32)]
        internal struct HOOK_REQUEST
        {
            [FieldOffset(0)] public UNICODE_STRING driverName; // 0..15
            [FieldOffset(16)] public short mode;                // 16..17
            [FieldOffset(18)]
            [MarshalAs(UnmanagedType.U1)]
            public bool fuzz;                                   // 18
            [FieldOffset(19)] public byte _pad0;               // pad → align short
            [FieldOffset(20)] public short type;               // 20..21
            [FieldOffset(22)] public ushort _pad1;            // pad → align pointer
            [FieldOffset(24)] public IntPtr address;          // 24..31 (PVOID*)
       }

        private void button7_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Select driver (.sys)";
                ofd.Filter = "Driver files (*.sys)|*.sys|All files (*.*)|*.*";
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog(this) != DialogResult.OK)
                    return;

                var serviceName = tbServiceName.Text.Trim();
                if (string.IsNullOrWhiteSpace(serviceName))
                {
                    MessageBox.Show(this, "Enter a service name.", "Driver Loader",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    Cursor = Cursors.WaitCursor;
                    int status = DriverLoader.LoadDriver(ofd.FileName, serviceName);
                    Cursor = Cursors.Default;

                    if (status == 0)
                    {
                        MessageBox.Show(this, "Driver loaded!", "Driver Loader",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, $"NtLoadDriver failed: 0x{status:X8}", "Driver Loader",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show(this, ex.Message, "Driver Loader",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Select driver (.sys)";
                ofd.Filter = "Driver files (*.sys)|*.sys|All files (*.*)|*.*";
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog(this) != DialogResult.OK)
                    return;

                var serviceName = tbServiceName.Text.Trim();
                if (string.IsNullOrWhiteSpace(serviceName))
                {
                    MessageBox.Show(this, "Enter a service name.", "Driver Loader",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    Cursor = Cursors.WaitCursor;
                    int status = DriverLoader.LoadDriver(ofd.FileName, serviceName);
                    Cursor = Cursors.Default;

                    if (status == 0)
                    {
                        MessageBox.Show(this, "Driver IOCTL Hook loaded", "Driver Loader",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, $"NtLoadDriver failed: 0x{status:X8}", "Driver Loader",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show(this, ex.Message, "Driver Loader",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            PopulateDevicesCombo(comboBox1); // replace with your ComboBox name

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}