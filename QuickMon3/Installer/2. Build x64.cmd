"C:\Program Files (x86)\WiX Toolset v3.8\bin\candle.exe" -out QuickMon3x64.winobj Productx64.wxs
"C:\Program Files (x86)\WiX Toolset v3.8\bin\light.exe" -out QuickMon3x64.msi QuickMon3x64.winobj -ext WixUIExtension -ext WixUtilExtension -ext WixNetfxExtension
pause