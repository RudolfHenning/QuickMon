function Get-MsiDatabaseVersion {
    param (
        [IO.FileInfo] $FilePath
    )

    try {
        $windowsInstaller = New-Object -com WindowsInstaller.Installer

        $database = $windowsInstaller.GetType().InvokeMember(
                "OpenDatabase", "InvokeMethod", $Null, 
                $windowsInstaller, @($FilePath.FullName, 0)
            )

        $q = "SELECT Value FROM Property WHERE Property = 'ProductVersion'"
        $View = $database.GetType().InvokeMember(
                "OpenView", "InvokeMethod", $Null, $database, ($q)
            )

        $View.GetType().InvokeMember("Execute", "InvokeMethod", $Null, $View, $Null)

        $record = $View.GetType().InvokeMember(
                "Fetch", "InvokeMethod", $Null, $View, $Null
            )

        $productVersion = $record.GetType().InvokeMember(
                "StringData", "GetProperty", $Null, $record, 1
            )

        return $productVersion

    } catch {
        throw "Failed to get MSI file version the error was: {0}." -f $_
    }
}

$currentDir = Get-Location
$filePath = [System.IO.Path]::Combine($currentDir, "QuickMon.exe")
if (Test-Path $filePath){
    $versionInfo = (Get-Command $filePath).FileVersionInfo.FileVersion
    $versionArray = $versionInfo.Split(".")
    $major = [int]$versionArray[0]
    $minor = [int]$versionArray[1]
    $str = "Latest exe version: " +  $major.ToString() + "." + $minor.ToString()
    $str
}

$sourcex86Msi = [System.IO.Path]::Combine($currentDir, "QuickMon3.msi")
if (Test-Path $sourcex86Msi){
    $versionInfo =  Get-MsiDatabaseVersion($sourcex86Msi)
    $versionArray = ([string]$versionInfo).Split(".")
    $major = [int]$versionArray[0]
    $minor = [int]$versionArray[1]
    $installerVersionNamex86 = "QuickMon" + $major + "." + $minor + ".msi"
    $installerVersionNamex86 = [System.IO.Path]::Combine($currentDir, $installerVersionNamex86)
    $str = "Renaming '" + $sourcex86Msi + "' to '" + $installerVersionNamex86 + "'"
    $str
    Copy-Item -Path $sourcex86Msi -Destination $installerVersionNamex86 -Force 
}

$sourcex64Msi = [System.IO.Path]::Combine($currentDir, "QuickMon3x64.msi")
if (Test-Path $sourcex64Msi){
    $versionInfo =  Get-MsiDatabaseVersion($sourcex64Msi)
    $versionArray = ([string]$versionInfo).Split(".")
    $major = [int]$versionArray[0]
    $minor = [int]$versionArray[1]
    $installerVersionNamex64 = "QuickMon" + $major + "." + $minor + "x64.msi"
    $installerVersionNamex64 = [System.IO.Path]::Combine($currentDir, $installerVersionNamex64)
    $str = "Renaming '" + $sourcex64Msi + "' to '" + $installerVersionNamex64 + "'"
    $str
    Copy-Item -Path $sourcex64Msi -Destination $installerVersionNamex64 -Force 
}

