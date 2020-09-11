using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace dotnetCoreWindowsServiceService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly dotnetCoreWindowsServiceCore.Config _config;

        public Worker(ILogger<Worker> logger, dotnetCoreWindowsServiceCore.Config config)
        {
            _logger = logger;
            _config = config;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("started");

            stoppingToken.Register(CancelledRequested);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var _coreClass = new dotnetCoreWindowsServiceCore.CoreClass(_logger, _config);
                    _logger.LogInformation("instance created");
                    await _coreClass.RunAsync(stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error, ErrorGuid: [3610bb5c-75c4-40a5-810c-2c748c365218]");
                    await Task.Delay(3000, stoppingToken);
                }
            }
        }
        private void CancelledRequested()
        {
            _logger.LogInformation("cancelled");

        }
    }
}
