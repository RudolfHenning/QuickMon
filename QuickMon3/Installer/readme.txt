QuickMon 3 Read me
---------------------------
Quick installation overview
---------------------------
The MSI installer basically only moves the executables (and dll's) to the installed machine at this time. To install the Windows service please see the 'How to install the Windows service' section.

------------------
List of components
------------------
1. QuickMon.exe - the standard UI tool
2. QuickMonRemoteHostCMD.exe - a command line version of the remote host tool (can be used for debugging)
3. QuickMonService.exe - the Windows service that can be used to run monitor packs without a user interface plus also the host service for 'remote host' functionality.
4. Dll's - the various components and agents needed by the executables.

----------------------------------
How to install the Windows service
----------------------------------
1. Open an 'Admin' command (cmd.exe) Window (Run as Admin)
2. Change directory to the QuickMon 3 installation directory (default C:\Program Files\Hen IT\QuickMon 3)
3. Run the following command:
   QuickMonService.exe -install
4. Specify an user account and password that has the permissions you require to access all the resources you need to monitor.
5. Before starting the service edit the file 'MonitorPackList.txt' to specify the location of all monitor pack files (full paths) you want to use.
   If you only want to use the service as a remote host then leave the file empty.
7. Start the service

-------------------------
Remote host functionality
-------------------------
To connect to a 'QuickMon Remote host' either the Windows service must be installed (and running) on that machine OR you can run the command line version. They cannot be run simultaneously for the same port number on the same machine.
Take note that the command line version requires an user to be logged into the remote machine running QuickMonRemoteHostCMD.exe. The Windows service can run without anyone logged onto the machine.

---------------------
Example Monitor packs
---------------------
Some example monitor packs are included in the installer. Please see the application install directory (default C:\Program Files\Hen IT\QuickMon 3\SamplePacks)