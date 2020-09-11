@echo off
set _ServiceName=appService

REM baslatma islemi --------------------------------
REM baslatma icin icin
ECHO %_ServiceName% trying to start
sc.exe start %_ServiceName%
REM baslatma islemi --------------------------------

PAUSE
