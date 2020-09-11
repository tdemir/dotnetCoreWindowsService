mkdir dotnetCoreWindowsService
cd ./dotnetCoreWindowsService

dotnet new sln

dotnet new classlib --name dotnetCoreWindowsServiceCore
dotnet sln dotnetCoreWindowsService.sln add ./dotnetCoreWindowsServiceCore/dotnetCoreWindowsServiceCore.csproj

dotnet new console --name dotnetCoreWindowsServiceConsole
dotnet sln dotnetCoreWindowsService.sln add ./dotnetCoreWindowsServiceConsole/dotnetCoreWindowsServiceConsole.csproj

dotnet new worker --name dotnetCoreWindowsServiceService
dotnet sln dotnetCoreWindowsService.sln add ./dotnetCoreWindowsServiceService/dotnetCoreWindowsServiceService.csproj