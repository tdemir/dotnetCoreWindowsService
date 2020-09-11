using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace dotnetCoreWindowsServiceService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args);

            host = OperatingSystem.IsWindows() ?
                    host.UseWindowsService() :
                    host.UseSystemd();

            host = host.ConfigureAppConfiguration(
                    (hostContext, config) =>
                    {
                        var location = System.Reflection.Assembly.GetEntryAssembly().Location;
                        var directoryPath = Path.GetDirectoryName(location);
                        config.SetBasePath(directoryPath);
                        config.AddJsonFile("appsettings.json", false, true);
                        //config.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", true, true);
                        //config.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", false, true);
                        config.AddEnvironmentVariables();
                        config.AddCommandLine(args);
                    }
            );


            host = host.ConfigureLogging(loggerFactory =>
            {
                var location = System.Reflection.Assembly.GetEntryAssembly().Location;
                var directoryPath = Path.GetDirectoryName(location);

                loggerFactory.AddFile(directoryPath + "/Logs/log-{Date}.txt");
            });

            host = host
                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration configuration = hostContext.Configuration;
                    var _config = configuration.GetSection("ServiceConfig").Get<dotnetCoreWindowsServiceCore.Config>();

                    services.AddSingleton(_config);

                    services.AddHostedService<Worker>();
                });

            return host;
        }
    }
}
