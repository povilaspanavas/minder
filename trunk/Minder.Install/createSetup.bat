pushd ..\
svn update
popd

pushd VersionFiles
For /F "Tokens=*" %%I in ('svnversion') Do Set version=%%I
echo %version% > REVISION
popd
call createSetupSimple.bat

echo press any key if you want to commit reniew version files
pause
pushd ..\
svn commit -m "#000 - atnaujinti versiju failai (paruostas atnaujinimas)."
popd