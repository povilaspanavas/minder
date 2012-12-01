@echo off
echo Started Core update
 

rem update core

rem build core before copying
call d:\Projektai\Core_tags\Core_2.0\Build.bat

rem copying
cd "../../../"
cd "d:\Projektai\Core_tags\Core_2.0\Core\bin\Debug\"
copy *.* "d:\Projektai\Minder_trunk\libs\"


echo CORE UPDATED SUCCESSFULLY! 
pause