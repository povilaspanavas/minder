mkdir bin\
del bin\*.* /Q

%windir%\microsoft.net\framework\v4.0.30319\msbuild /p:Configuration=Release /p:SharpDevelopBinPath="C:\Program Files (x86)\SharpDevelop\4.3\bin" ..\Minder.sln

"NSIS\makensis" "Scripts\minder.nsi"
pause