QuickMon 5 Read me
---------------------------
Quick installation overview
---------------------------
The MSI installer basically only moves the executables (and dll's) to the installed machine at this time. 
To install the Windows service please see the 'How to install the Windows service' section.

------------------
List of components
------------------
1. QuickMon.exe - the standard UI tool
2. QuickMonService.exe - the Windows service that can be used to run monitor packs without a user interface plus also the host service for 'remote host' functionality.
3. Dll's - the various components and agents needed by the executables.

----------------------------------
How to install the Windows service
----------------------------------
1. Open QuickMon.exe in Admin mode
2. Open Remote Hosts window (Ctrl+H)
3. If the service has not been installed yet you will see an option to 'Install Service/Remote host'
4. Click on this link and the service installation dialog will show up.
5. Specify a user name and password to be used to run the service.
6. Also remember to click the 'Add firewall exception' rule.
