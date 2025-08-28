# IOCTL++ [![](https://ci.appveyor.com/api/projects/status/github/jthuraisamy/ioctlpus?branch=master&svg=true&passingText=Download)](https://github.com/jsacco/ioctlplusplus/archive/refs/heads/main.zip)

IOCTL++ can be used to make `DeviceIoControl` requests with arbitrary inputs. 
The original tool has been improved with a driver hooker allowing the user to capture the data and config of IOCTLs of the target application during runtime.

Here is an example of an ZwTerminationProcess triggered in a sample vulnerable driver:

<p align="center"><img src="https://i.imgur.com/p2kfNjN.png" /></p>

## How to use:
1. Run the tool with admin rights.
2. Start the kernel hook. This driver will allow you to hook IOCTLs from the target driver.
3. If not loaded yet, you can load the target driver using IOCTL++
4. Select from Device combo the target Driver name, and click on Hook IOCTLs to enable the hooking of the IOCTls from the DriverHooks <-> Target Driver
5. Trigger IOCTLs in your target driver from usermode.
6. Click on Load config from Hook and go to C:\DriverHooks and select the .conf file <- This will populate the Device, IOCTL Code, Input and Output sizes, also it will decode the IOCTL code.
7. Click on Load data from Hook and go to C:\DriverHooks and select the .data file <- This will populate the data buffer
8. Modify the buffer, or not, and Click on Replay to send your original or custom data to the IOCTL from your target driver
9. Debug with WinDBG + Retsync, build exploit and repeat.
10. Profit?

## Similar Tools

- [jerome-pouiller / ioctl](https://github.com/jerome-pouiller/ioctl)
- [xst3nz / ioctlbf](https://code.google.com/archive/p/ioctlbf/)

## Licence

[GPLv3](https://tldrlegal.com/license/gnu-general-public-license-v3-(gpl-3))
