@echo off
echo Started Core update
 

rem update core

rem build core before copying
call c:\Dokumentai\Projektai\Core_tags\Core_1.5\Build.bat

rem copying
cd "../../../"
cd "c:\Dokumentai\Projektai\Core_tags\Core_1.5\Core\bin\Debug\"
copy *.* "c:\Dokumentai\Projektai\Minder\libs\"


echo CORE UPDATED SUCCESSFULLY! 
pause