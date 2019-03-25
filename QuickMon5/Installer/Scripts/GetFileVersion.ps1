param(
  [cmdletbinding()]
  [parameter(position=0,mandatory=$true,valuefrompipeline=$true,ValueFromPipelineByPropertyName=$true)][string]$filePath
)
begin {
}
process {
    $filePath = $filePath.Trim('"')
    $versionInfo = ""

    if (Test-Path $filePath){
        $versionInfo = (Get-Command $filePath).FileVersionInfo.FileVersion
    }
    if ($versionInfo -eq ""){
        "File not found!"
    }
    else {
        $versionArray = $versionInfo.Split(".")
        $major = [int]$versionArray[0]
        $minor = [int]$versionArray[1]
        $build = [int]$versionArray[2]
        $str = $major.ToString() + "." + $minor.ToString() + "." + $build.ToString()
        $str
    }
}
end {
}