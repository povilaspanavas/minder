@echo off
path = "..\Minder\Minder.csproj"
DEL Build.log

"C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild" %path% /t:Rebuild >> Build.log && type Build.log

rem if exist "..\Minder\bin\debug\log" RD "..\Minder\bin\debug\log" /S /Q
rem DEL "Builded installs\*.*" /Q 
rd "Install Files" /s/q
md "Install Files"
md "Install Files/bin/files"
md "Install Files/DB"

copy "..\Minder\bin\debug\*.*" "Install Files\bin\files"
copy "..\Minder\DB\*.*" "Install Files\DB"
if exist "Install Files\bin\log" RD "..\Minder\bin\debug\log" /S /Q
del "Install Files\DB\minderdb.db" /Q
del "Install Files\bin\files\*.pdb" /Q
del "Install Files\bin\files\*.ini" /Q
copy "Install Files\DB\emptyminderdb.db" "Install Files\DB\MinderDb.db"
pause