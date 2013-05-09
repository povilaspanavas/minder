Two ways to create install:
1. Call createSetup.bat, which will first reniew revision number and later call createSetupSimple.bat. After that it will commit reniewed revision version to svn.
2. Call createSetupSimple.bat, which compiles and creates install file at bin\Minder_Setup_v*****.exe