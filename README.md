### IOCTL++ 
It's a tool that can make DeviceIoControl requests with arbitrary inputs. The original tool has been improved with a driver helper and a driver hooker allowing the user to capture the data and config of IOCTLs of the target application during runtime.

## Workflow of IOCTL++:
1. Start the kernel hook. This action is going to load a second helper driver, this driver will allow you to hook IOCTLs from the target driver.
2. If not loaded yet, you can load the target driver using IOCTL++ (top-right)
3. Select from device to be hooked, and click on Hook IOCTLs to enable the hooking of the IOCTLs from the DriverHooks <-> Target Driver
4. If you cannot find or don't know the device name, use the Driver Links either UM or KM, to find the device name.
5. Trigger an IOCTL in your target driver.
6. Click on Load config from Hook and go to C:\DriverHooks and select the .conf file <- This will populate the Device, IOCTL Code, Input and Output sizes, also it will decode the IOCTL code.
7. Click on Load data from Hook and go to C:\DriverHooks and select the .data file <- This will populate the data buffer
8. Modify the buffer, or not, and Click on Replay to send your original or custom data to the IOCTL from your target driver
9. Debug with WinDBG + Retsync, build exploit and repeat.

As soon as you launch the tool (with admin rights) you will be prompted to load the Kernel Driver (helper) that will be used to access the list of drivers, from the kernel space, and read debugging messages from the kernel, similar to DbgView.

<img src="https://cdn.shopify.com/s/files/1/0918/4162/6445/files/Screenshot_from_2025-09-25_18-45-34.png?v=1758818832">

And here is the main windows of the tool where you can see the features such as: IOCTL Hooker, driver listing from user mode, driver listing from kernel mode (using the driver) and kernel log.

<img src="https://cdn.shopify.com/s/files/1/0918/4162/6445/files/Screenshot_from_2025-09-25_18-47-41.png?v=1758818962">

Driver Links Kernel tab. After you have loaded your target driver, if you refresh this tab then you will see the deltas (if there is a difference with the previous state) of the list, this will allow you to easily and quickly catch the driver name, then you can right click on it and select to use it in IOCTL Tab.

<img src="https://cdn.shopify.com/s/files/1/0918/4162/6445/files/Screenshot_from_2025-09-25_18-55-21.png?v=1758819333">

Kernel Log, it's similar to DbgView tool from Sysinternals but it's much more handy to have it on the tool itself to catch debugging messages or if you are doing DbgPrints from Kernel as a proof of concept.

<img src="https://cdn.shopify.com/s/files/1/0918/4162/6445/files/Screenshot_from_2025-09-25_18-56-12.png?v=1758819444">

