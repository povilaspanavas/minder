@echo off
echo Started Core update
 

rem update core

rem build core before copying
call ..\Core\Build.bat

rem copying
rem cd "../../../"
rem cd "..\Core\Core\bin\Debug\"
copy "..\Core\Core\bin\Debug\*.*" "libs"


echo CORE UPDATED SUCCESSFULLY! 
pause