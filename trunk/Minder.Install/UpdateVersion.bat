RevisionUpdater\RevisionUpdater.exe --TagFile VersionFiles\VERSION --ReplaceRevision Scripts\minder.version --InsertVersion-- Scripts\minder.nsi --enc Default
del Scripts\minder.version

RevisionUpdater\RevisionUpdater.exe --TagFile VersionFiles\VERSION --ReplaceRevision ..\Minder\version.version --InsertVersion-- ..\Minder\version.cvr --enc Default
del ..\Minder\version.version

REM RevisionUpdater\RevisionUpdater.exe --TagFile VersionFiles\VERSION --ReplaceRevision Scripts\RBU_Easy_Update_Client_Install.version --InsertVersion-- Scripts\RBU_Easy_Update_Client_Install.nsi --enc Default
REM del Scripts\RBU_Easy_Update_Client_Install.version

