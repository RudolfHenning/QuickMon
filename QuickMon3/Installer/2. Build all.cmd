"C:\Program Files (x86)\WiX Toolset v3.8\bin\candle.exe" -out QuickMon3x64.winobj Productx64.wxs
"C:\Program Files (x86)\WiX Toolset v3.8\bin\light.exe" -out QuickMon3x64.msi QuickMon3x64.winobj -ext WixUIExtension -ext WixUtilExtension -ext WixNetfxExtension
"C:\Program Files (x86)\WiX Toolset v3.8\bin\candle.exe" -out QuickMon3.winobj Product.wxs
"C:\Program Files (x86)\WiX Toolset v3.8\bin\light.exe" -out QuickMon3.msi QuickMon3.winobj -ext WixUIExtension -ext WixUtilExtension -ext WixNetfxExtension

"C:\Program Files\7-Zip\7z.exe" a -mx9 IISAgents.zip QuickMonIISAgents.dll
"C:\Program Files\7-Zip\7z.exe" a -mx9 IISAgents.zip ExtraAgentsReadme.txt
"C:\Program Files\7-Zip\7z.exe" a -mx9 IISAgents.zip InstallIISAgents.cmd
"C:\Program Files\7-Zip\7z.exe" a -mx9 IISAgents.zip CopyAsAdmin.exe
"C:\Program Files\7-Zip\7z.exe" a -mx9 IISAgents.zip CopyAsAdmin.exe.config

"C:\Program Files\7-Zip\7z.exe" a -mx9 BizTalkAgents.zip QuickMonBizTalkAgents.dll
"C:\Program Files\7-Zip\7z.exe" a -mx9 BizTalkAgents.zip ExtraAgentsReadme.txt
"C:\Program Files\7-Zip\7z.exe" a -mx9 BizTalkAgents.zip InstallBizTalkAgents.cmd
"C:\Program Files\7-Zip\7z.exe" a -mx9 BizTalkAgents.zip CopyAsAdmin.exe
"C:\Program Files\7-Zip\7z.exe" a -mx9 BizTalkAgents.zip CopyAsAdmin.exe.config

"C:\Program Files\7-Zip\7z.exe" a -mx9 OLEDBAgents.zip QuickMonOLEDBAgents.dll
"C:\Program Files\7-Zip\7z.exe" a -mx9 OLEDBAgents.zip ExtraAgentsReadme.txt
"C:\Program Files\7-Zip\7z.exe" a -mx9 OLEDBAgents.zip InstallOLEDBAgents.cmd
"C:\Program Files\7-Zip\7z.exe" a -mx9 OLEDBAgents.zip CopyAsAdmin.exe
"C:\Program Files\7-Zip\7z.exe" a -mx9 OLEDBAgents.zip CopyAsAdmin.exe.config

"C:\Program Files\7-Zip\7z.exe" a -mx9 MSSQLAgents.zip QuickMonSQLAgents.dll
"C:\Program Files\7-Zip\7z.exe" a -mx9 MSSQLAgents.zip ExtraAgentsReadme.txt
"C:\Program Files\7-Zip\7z.exe" a -mx9 MSSQLAgents.zip InstallMSSQLAgents.cmd
"C:\Program Files\7-Zip\7z.exe" a -mx9 MSSQLAgents.zip CopyAsAdmin.exe
"C:\Program Files\7-Zip\7z.exe" a -mx9 MSSQLAgents.zip CopyAsAdmin.exe.config

"C:\Program Files\7-Zip\7z.exe" a -mx9 PowerShellAgents.zip QuickMonPowerShellAgents.dll
"C:\Program Files\7-Zip\7z.exe" a -mx9 PowerShellAgents.zip ExtraAgentsReadme.txt
"C:\Program Files\7-Zip\7z.exe" a -mx9 PowerShellAgents.zip InstallPowerShellAgents.cmd
"C:\Program Files\7-Zip\7z.exe" a -mx9 PowerShellAgents.zip CopyAsAdmin.exe
"C:\Program Files\7-Zip\7z.exe" a -mx9 PowerShellAgents.zip CopyAsAdmin.exe.config
pause