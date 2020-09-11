set appEnvType=Production
if exist "%CD%\release\%appEnvType%\" rmdir /s /q "%CD%\release\%appEnvType%"
if exist "%CD%\release\%appEnvType%\" del /s /q "%CD%\release\%appEnvType%"
dotnet publish "%CD%\..\dotnetCoreWindowsServiceService\dotnetCoreWindowsServiceService.csproj" --output "%CD%\release\%appEnvType%" --configuration Debug /p:EnvironmentName=%appEnvType%

@echo **************************************************
@echo             %appEnvType% Publish succeed
@echo Publish Path   %CD%\release\%appEnvType%
@echo **************************************************

echo f | xcopy /f /y "%CD%\ServiceDelete.bat" "%CD%\release\%appEnvType%\ServiceDelete.bat"
echo f | xcopy /f /y "%CD%\ServiceInstall.bat" "%CD%\release\%appEnvType%\ServiceInstall.bat"
echo f | xcopy /f /y "%CD%\ServiceStart.bat" "%CD%\release\%appEnvType%\ServiceStart.bat"

@echo **************************************************
@echo Scripts copied
@echo **************************************************

@PAUSE