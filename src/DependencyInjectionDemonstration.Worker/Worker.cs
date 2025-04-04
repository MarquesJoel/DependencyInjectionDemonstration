using DependencyInjectionDemonstration.Core.Services;
using DependencyInjectionDemonstration.Core.UseCases;

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

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"IGuidServiceTransient: {_guidServiceTransient.GetGuid()}");
            _logger.LogInformation($"IUseCaseDemoTransient: {_demoTransient.GetGuid()}");

            return Task.CompletedTask;
        }


       
        
        
        
        
        
        
        
        
        
        //private readonly IServiceScopeFactory _scopeFactory;

        //public Worker(IServiceScopeFactory scopeFactory)
        //{
        //    _scopeFactory = scopeFactory;
        //}

        //protected override Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        //    using (var scope = _scopeFactory.CreateScope())
        //    {
        //        var useCaseScoped = scope.ServiceProvider.GetRequiredService<IUseCaseDemoSoped>();
        //        _logger.LogInformation($"IUseCaseDemoScoped: {useCaseScoped.GetGuid()}");

        //        var guidServiceScoped = scope.ServiceProvider.GetRequiredService<IGuidServiceScoped>();
        //        _logger.LogInformation($"IGuidServiceScoped: {guidServiceScoped.GetGuid()}");


        //    }

        //    return Task.CompletedTask;
        //}
    }
}
