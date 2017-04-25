set WIXDIR=C:\Program Files (x86)\WiX Toolset v3.9\bin
"%WIXDIR%\candle.exe" -out QuickMon5x64.winobj Productx64.wxs
"%WIXDIR%\light.exe" -out QuickMon5x64.msi QuickMon5x64.winobj -ext WixUIExtension -ext WixUtilExtension -ext WixNetfxExtension
"%WIXDIR%\candle.exe" -out QuickMon5.winobj Product.wxs
"%WIXDIR%\light.exe" -out QuickMon5.msi QuickMon4.winobj -ext WixUIExtension -ext WixUtilExtension -ext WixNetfxExtension

powershell -File SetInstallerNames.ps1
WaitOrKey.exe 5