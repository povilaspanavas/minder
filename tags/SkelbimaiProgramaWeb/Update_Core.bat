@echo off
echo Started Core update
 

rem update core

rem build core before copying
Pushd d:\Projektai\Core_tags\Core_2.5
call d:\Projektai\Core_tags\Core_2.5\Build.bat 

rem copying
cd "d:\Projektai\Core_tags\Core_2.5\Core\bin\Debug\"
copy *.* "d:\Projektai\SkelbimaiProgramaWeb\BussinessLogic\libs\"


echo CORE UPDATED SUCCESSFULLY! 
pause