set WIXDIR=C:\Program Files (x86)\WiX Toolset v3.8\bin
"%WIXDIR%\candle.exe" -out QuickMon3x64.winobj Productx64.wxs
"%WIXDIR%\light.exe" -out QuickMon3x64.msi QuickMon3x64.winobj -ext WixUIExtension -ext WixUtilExtension -ext WixNetfxExtension
"%WIXDIR%\candle.exe" -out QuickMon3.winobj Product.wxs
"%WIXDIR%\light.exe" -out QuickMon3.msi QuickMon3.winobj -ext WixUIExtension -ext WixUtilExtension -ext WixNetfxExtension

powershell -File SetInstallerNames.ps1
WaitOrKey.exe 5

rem "C:\Program Files\7-Zip\7z.exe" a -mx9 IISAgents.zip QuickMonIISAgents.dll
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 IISAgents.zip ExtraAgentsReadme.txt
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 IISAgents.zip InstallIISAgents.cmd
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 IISAgents.zip CopyAsAdmin.exe
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 IISAgents.zip CopyAsAdmin.exe.config

rem "C:\Program Files\7-Zip\7z.exe" a -mx9 BizTalkAgents.zip QuickMonBizTalkAgents.dll
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 BizTalkAgents.zip ExtraAgentsReadme.txt
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 BizTalkAgents.zip InstallBizTalkAgents.cmd
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 BizTalkAgents.zip CopyAsAdmin.exe
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 BizTalkAgents.zip CopyAsAdmin.exe.config

rem "C:\Program Files\7-Zip\7z.exe" a -mx9 OLEDBAgents.zip QuickMonOLEDBAgents.dll
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 OLEDBAgents.zip ExtraAgentsReadme.txt
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 OLEDBAgents.zip InstallOLEDBAgents.cmd
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 OLEDBAgents.zip CopyAsAdmin.exe
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 OLEDBAgents.zip CopyAsAdmin.exe.config

rem "C:\Program Files\7-Zip\7z.exe" a -mx9 MSSQLAgents.zip QuickMonSQLAgents.dll
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 MSSQLAgents.zip ExtraAgentsReadme.txt
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 MSSQLAgents.zip InstallMSSQLAgents.cmd
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 MSSQLAgents.zip CopyAsAdmin.exe
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 MSSQLAgents.zip CopyAsAdmin.exe.config

rem "C:\Program Files\7-Zip\7z.exe" a -mx9 PowerShellAgents.zip QuickMonPowerShellAgents.dll
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 PowerShellAgents.zip System.Management.Automation.dll
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 PowerShellAgents.zip ExtraAgentsReadme.txt
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 PowerShellAgents.zip InstallPowerShellAgents.cmd
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 PowerShellAgents.zip CopyAsAdmin.exe
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 PowerShellAgents.zip CopyAsAdmin.exe.config

rem "C:\Program Files\7-Zip\7z.exe" a -mx9 AllAgents.zip QuickMonIISAgents.dll
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 AllAgents.zip QuickMonBizTalkAgents.dll
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 AllAgents.zip QuickMonDirectoryServicesAgents.dll
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 AllAgents.zip QuickMonOLEDBAgents.dll
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 AllAgents.zip QuickMonSQLAgents.dll
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 AllAgents.zip QuickMonPowerShellAgents.dll
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 AllAgents.zip QuickMonWebServiceAgents.dll
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 AllAgents.zip System.Management.Automation.dll
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 AllAgents.zip ExtraAgentsReadme.txt
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 AllAgents.zip InstallAllAgents.cmd
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 AllAgents.zip CopyAsAdmin.exe
rem "C:\Program Files\7-Zip\7z.exe" a -mx9 AllAgents.zip CopyAsAdmin.exe.config
pause