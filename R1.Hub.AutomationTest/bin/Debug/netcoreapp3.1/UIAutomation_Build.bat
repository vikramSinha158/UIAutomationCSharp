@echo off
SETLOCAL ENABLEDELAYEDEXPANSION

@set projectVersion=%1

@if "" equ %projectVersion% (
	echo Version is required
	EXIT /b 1
)

if not defined DevEnvDir (
	IF EXIST "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\Tools\vsdevcmd.bat" (
		call "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\Tools\vsdevcmd.bat"
		goto :build
	) 
	IF EXIST "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\Tools\vsdevcmd.bat" (
		call "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\Tools\vsdevcmd.bat"
		goto :build
	) 
	IF EXIST "C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\Common7\Tools\vsdevcmd.bat" (
		call "C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\Common7\Tools\vsdevcmd.bat"
		goto :build
	) 
	IF EXIST "C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\Common7\Tools\vsdevcmd.bat" (
		call "C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\Common7\Tools\vsdevcmd.bat"
		goto :build
	)
)

:build

if not defined DevEnvDir (
	exit /b 1;
)

nuget restore R1.Hub.UIAutomation.sln
@IF NOT %ERRORLEVEL% == 0 EXIT /b %ERRORLEVEL%
msbuild ./R1.Hub.UIAutomation.sln /t:restore /p:RestoreConfigFile=.nuget\nuget.config /t:Build /p:Configuration=Debug;AssemblyFileVersion=%projectVersion% /p:DebugSymbols=false /p:DebugType=None /p:DocumentationFile="" /m /nr:false
EXIT /b %ERRORLEVEL%

ENDLOCAL