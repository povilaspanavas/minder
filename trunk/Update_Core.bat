@echo off
echo Started Core update
 

rem update core

rem build core before copying
call d:\Projektai\Core\Build.bat

rem copying
cd "../../../"
cd "d:\Projektai\Core\Core\bin\Debug\"
copy *.* "d:\Projektai\Easy remainder\trunk\EasyRemainder\libs\"


echo CORE UPDATED SUCCESSFULLY! 
pause