mkdir bin\temp
copy bin\Minder*.* bin\temp
ren bin\temp\Minder*.* mindersetup.exe
copy bin\temp\mindersetup.exe bin
rmdir bin\temp /Q /S