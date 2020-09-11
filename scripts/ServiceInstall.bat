@echo off
set _ServiceName=appService

REM Olusturma islemi --------------------------------
REM olusturmak icin icin
ECHO %_ServiceName% trying to create
sc.exe create %_ServiceName% binPath= "%CD%\dotnetCoreWindowsServiceService.exe" start= auto DisplayName= "App Service" obj= "LocalSystem"
REM Olusturma islemi --------------------------------

REM baslatma islemi --------------------------------
REM baslatma icin icin
ECHO %_ServiceName% trying to start
sc.exe start %_ServiceName%
REM baslatma islemi --------------------------------

PAUSE