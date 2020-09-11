using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace dotnetCoreWindowsServiceConsole
{
    class Program
    {
        static ServiceProvider serviceProvider;
        static async Task Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            CreateServiceProvider();

            // get instance of logger
            var logger = serviceProvider.GetService<ILogger<Program>>();

            var config = new dotnetCoreWindowsServiceCore.Config()
            {
                Timeout = 3
            };
            var _coreClass = new dotnetCoreWindowsServiceCore.CoreClass(logger, config);
            await _coreClass.RunAsync(cts.Token);
        }

        static void CreateServiceProvider()
        {
            // instantiate DI and configure logger
            serviceProvider = new ServiceCollection()
                    .AddLogging(cfg => cfg.AddConsole())
                    .Configure<LoggerFilterOptions>(cfg => cfg.MinLevel = LogLevel.Debug)
                    .BuildServiceProvider();
        }
    }
}
