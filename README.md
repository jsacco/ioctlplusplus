### IOCTL++ 
It's a tool that can make DeviceIoControl requests with arbitrary inputs. The original tool has been improved with a driver helper and a driver hooker allowing the user to capture the data and config of IOCTLs of the target application during runtime.

As soon as you launch the tool (with admin rights) you will be prompted to load the Kernel Driver (helper) that will be used to access the list of drivers, from the kernel space, and read debugging messages from the kernel, similar to DbgView.

<img src="https://cdn.shopify.com/s/files/1/0918/4162/6445/files/Screenshot_from_2025-09-25_18-45-34.png?v=1758818832">
