@echo off
path = "..\Minder\Minder.csproj"

"C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild" %path% /t:Rebuild >> Build.log && type Build.log

if exist "..\Minder\bin\debug\log" RD "..\Minder\bin\debug\log" /S /Q
DEL "Builded installs\*.*" /Q 

pause