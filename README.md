# IOCTL++ [![](https://ci.appveyor.com/api/projects/status/github/jthuraisamy/ioctlpus?branch=master&svg=true&passingText=Download)](https://github.com/jsacco/ioctlplusplus/archive/refs/heads/main.zip)

IOCTL++ can be used to make `DeviceIoControl` requests with arbitrary inputs. 
The original tool has been improved with a driver hooker allowing the user to capture the data and config of IOCTLs of the target application during runtime.

Here is an example of an information leak triggered in a sample vulnerable driver:

<p align="center"><img src="https://i.imgur.com/p2kfNjN.png" /></p>

## Similar Tools

- [jerome-pouiller / ioctl](https://github.com/jerome-pouiller/ioctl)
- [xst3nz / ioctlbf](https://code.google.com/archive/p/ioctlbf/)

## Licence

[GPLv3](https://tldrlegal.com/license/gnu-general-public-license-v3-(gpl-3))
