Param()

function GetNumDots([Parameter(Mandatory = $true)][string]$Value) {
    if ([string]::IsNullOrWhiteSpace($Value)) {
        throw "String $Value was null or whitespace"
    }
    [System.Int32]$_index = $Value.IndexOf(".")
    [System.Int32]$_num = 0
    while($_index -gt -1) {
        $_num++
        $_index = $Value.IndexOf(".", $_index + 1)
    }
    return $_num
}

function GetPackageVersion([Parameter(Mandatory = $true)][string]$FileVersion) {
    if ([string]::IsNullOrWhiteSpace($FileVersion)) {
        throw "String $FileVersion was null or whitespace"
    }
    [string]$_packageVersion = ""
    if ($FileVersion.StartsWith("0")) {
        return "1.0.0"
    }
    if ($FileVersion.Contains(" ")) {
        $FileVersion = $FileVersion.Substring(0, $FileVersion.IndexOf(" "))
    }
    $numDots = GetNumDots -Value $FileVersion
    if ($numDots -gt 3) {
        throw "Num dots was greater than 3"
    }
    for (($i = $numDots); $i -lt 3; $i++) {
        $FileVersion = $FileVersion + ".0"
    }
    $_packageVersion = $FileVersion.Substring(0, $FileVersion.LastIndexOf("."))
    return $_packageVersion
}

GetNumDots -Value "0" | Write-Host
GetNumDots -Value "0.0" | Write-Host
GetNumDots -Value "0.0.0" | Write-Host
GetNumDots -Value "0.0.0.0" | Write-Host
GetPackageVersion -FileVersion "0" | Write-Host
GetPackageVersion -FileVersion "0.0" | Write-Host
GetPackageVersion -FileVersion "0.0.0" | Write-Host
GetPackageVersion -FileVersion "0.0.0.0" | Write-Host
GetPackageVersion -FileVersion "1.2.3.4" | Write-Host
GetPackageVersion -FileVersion "1.2.3.4 (Some text)" | Write-Host
GetPackageVersion -FileVersion "1" | Write-Host
GetPackageVersion -FileVersion "1.2" | Write-Host
GetPackageVersion -FileVersion "1.2.3" | Write-Host