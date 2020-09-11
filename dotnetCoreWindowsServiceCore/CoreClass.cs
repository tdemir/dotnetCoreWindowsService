using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace dotnetCoreWindowsServiceCore
{
    public class CoreClass
    {
        ILogger _logger;
        Config _config;
        public CoreClass(ILogger logger, Config config)
        {
            _logger = logger;
            _config = config;
        }


        public async Task RunAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Read system information...");
            //Config config = JsonSerializer.Deserialize<Config>(await File.ReadAllTextAsync("config.json"));

            while (!stoppingToken.IsCancellationRequested)
            {

                // sleep for 3 secs
                _logger.LogInformation($"Waiting...{_config.Timeout} seconds");
                //Thread.Sleep(config.TemperatureControlPeriodInSeconds * 1000);
                await Task.Delay(_config.Timeout * 1000, stoppingToken);
            }
        }

    }
}