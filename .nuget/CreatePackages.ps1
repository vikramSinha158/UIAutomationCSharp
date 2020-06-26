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

[string]$global:NUGET = "C:\Program Files (x86)\NuGet\bin\nuget.exe"
[string]$global:APIKEY = "oy2fpmhwybx56k6rehtqnnza3brvqq5eliclpahkxfbmlm"

$assemblies = Get-ChildItem -Filter "*.dll"
$directories = dir -Directory
foreach ($directory in $directories) {
    Remove-Item -Path $directory.FullName -Recurse -Force
}
if (Test-Path "packages") {
    Remove-Item -Path "packages" -Recurse -Force
}
New-Item -Name "packages" -ItemType directory

foreach ($assembly in $assemblies) {
    [string]$packageName = ""
    [string]$destinationPath = ""
    [string]$assemblyNameNoExt = ""
    [string]$xmlFilename = ""
    [string]$xmlDestinationPath = ""
    [string]$nuspecFilename = ""
    [string]$version = ""
    [string]$packageVersion = ""
    [string]$nuspecFilename = ""
    [string]$nuspecContent = ""
    [string]$nupkgName = ""

    Write-Host "Processing $($assembly.Name)"
    $packageName = "R1-" + $assembly.Name.Replace(" ", ".").Substring(0,$assembly.Name.Length - 4)
    $assemblyNameNoExt = $assembly.Name.Substring(0,$assembly.Name.Length - 4)
    Write-Host "Creating package $($packageName)"
    if (-Not(Test-Path $packageName)) {
        New-Item -Name $packageName -ItemType directory
        New-Item -Name "lib" -Path $packageName -ItemType directory
        New-Item -Name "net40" -Path ($packageName + "\\lib") -ItemType directory
        Write-Host "Created directory structure for $($packageName)"
    }
    $destinationPath = ($packageName + "\lib\net40" + $assembly.Name)
    $xmlFilename = $assemblyNameNoExt + ".xml"
    if (-Not(Test-Path $destinationPath)) {
        Copy-Item -Path $assembly.Name -Destination ($packageName + "\lib\net40")
        Write-Host "Copied assembly $($assembly.Name) to $($destinationPath)"
    }
    if (Test-Path $xmlFilename) {
        $xmlDestinationPath = $packageName + "\lib\net40\" + $xmlFilename
        if (-Not(Test-Path $xmlDestinationPath)) {
            Copy -Path $xmlFilename -Destination $xmlDestinationPath
            Write-Host "Copied $($xmlFilename) to $($xmlDestinationPath)"
        }
    }
    $nuspecFilename = $packageName + ".nuspec"
    Write-Host "Assembly FileVersion $($assembly.VersionInfo.FileVersion)"
    $version = $assembly.VersionInfo.FileVersion
    Write-Host "Version $($version)"
    if ([string]::IsNullOrWhiteSpace($version)) {
        throw "Unable to determine product version inspecting $($assembly)."
    }
    $packageVersion = GetPackageVersion -FileVersion $version
    Write-Host "Package version $($packageVersion)"
    $nuspecContent = "<package xmlns=""http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd"">
    <metadata>
        <id>$($packageName)</id>
        <version>$($packageVersion)</version>
        <description>$($assembly.Name)</description>
        <authors>R1 RCM</authors>
		<projectUrl>https://www.r1rcm.com/</projectUrl>
		<requireLicenseAcceptance>false</requireLicenseAcceptance>
    </metadata>
</package>"
    if (-Not(Test-Path $nuspecFilename)) {
        New-Item -Name $nuspecFilename -Path $packageName 
        Set-Content -Path ($packageName + "\" + $nuspecFilename) -Value $nuspecContent
    }
    Set-Location -Path ".\$($packageName)"
    & $NUGET pack $nuspecFilename
    Write-Host "Package version $($packageVersion)"
    $nupkgName = $packageName + "." + $packageVersion.ToString() + ".nupkg"
    Write-Host "Package version $($packageVersion)"
    Write-Host "Package filename $($nupkgName)"
    if (-Not(Test-Path $nupkgName)) {
        throw "$($nupkgName) not found"
    }
    Move-Item -Path $nupkgName -Destination "..\packages"
    # & $NUGET push $nupkgName $APIKEY -source https://nuget.accretivehealth.local/nuget/api/v2 -SkipDuplicate
    Set-Location -Path ".."
}
