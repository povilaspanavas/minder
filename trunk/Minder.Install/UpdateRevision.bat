RevisionUpdater\RevisionUpdater.exe --TagFile VersionFiles\REVISION --ReplaceRevision Scripts\minder.template --InsertRevision-- Scripts\minder.version --enc Default

REM RevisionUpdater\RevisionUpdater.exe --TagFile VersionFiles\REVISION --ReplaceRevision ..\PUV\RevisionClass.template --InsertRevision-- ..\PUV\RevisionClass.cs --enc Default

rem %windir%\microsoft.net\framework\v3.5\msbuild /p:Configuration=Debug /p:SharpDevelopBinPath="C:\Program Files\SharpDevelop\3.0\bin" ..\PUV.sln
rem @IF %ERRORLEVEL% NEQ 0 PAUSE