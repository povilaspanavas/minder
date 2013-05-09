pushd ..\
svn update
popd

pushd VersionFiles
For /F "Tokens=*" %%I in ('svnversion') Do Set version=%%I
echo %version% > REVISION
popd
call createSetup.bat