@echo off
set _ServiceName=appService


REM 5 seconds sleep
rem SLEEP 5

REM Silme islemi --------------------------------
SC QUERY %_ServiceName% > NUL
IF ERRORLEVEL 1060 GOTO MISSING
ECHO %_ServiceName% SERVICE EXISTS
REM durdurmak icin
ECHO %_ServiceName% trying to Stop
sc.exe stop %_ServiceName%
REM silmek icin
ECHO %_ServiceName% trying to delete
sc.exe delete %_ServiceName%
GOTO END

:MISSING
ECHO %_ServiceName% SERVICE MISSING

:END
REM Silme islemi --------------------------------

PAUSE