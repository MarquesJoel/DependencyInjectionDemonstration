using DependencyInjectionDemonstration.Worker.Services;
using DependencyInjectionDemonstration.Worker.UseCases;

namespace DependencyInjectionDemonstration.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IUseCaseDemoTransient _demoTransient;
        private readonly IGuidServiceTransient _guidServiceTransient;

        public Worker(
            ILogger<Worker> logger, 
            IUseCaseDemoTransient demoTransient, 
            IGuidServiceTransient guidServiceTransient)
        {
            _logger = logger;
            _demoTransient = demoTransient;
            _guidServiceTransient = guidServiceTransient;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"IGuidServiceTransient: {_guidServiceTransient.GetGuid()}");
            _logger.LogInformation($"IUseCaseDemoTransient: {_demoTransient.GetGuid()}");

            //while (!stoppingToken.IsCancellationRequested)
            //{
            //    if (_logger.IsEnabled(LogLevel.Information))
            //    {
            //        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            //    }
            //    await Task.Delay(1000, stoppingToken);
            //}
        }
    }
}
