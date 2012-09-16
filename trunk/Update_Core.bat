@echo off
echo Started Core update
 

rem update core

rem build core before copying
call c:\Dokumentai\Projektai\Core\Build.bat

rem copying
cd "../../../"
cd "c:\Dokumentai\Projektai\Core\Core\bin\Debug\"
copy *.* "c:\Dokumentai\Projektai\Minder\libs\"


echo CORE UPDATED SUCCESSFULLY! 
pause