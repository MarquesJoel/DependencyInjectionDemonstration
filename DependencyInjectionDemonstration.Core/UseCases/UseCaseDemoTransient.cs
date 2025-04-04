using DependencyInjectionDemonstration.Core.Services;
using Microsoft.Extensions.Logging;

namespace DependencyInjectionDemonstration.Core.UseCases
{

    public class UseCaseDemoTransient: IUseCaseDemoTransient, IDisposable
    {
        private readonly IGuidServiceTransient _guidService;

        private readonly ILogger<UseCaseDemoTransient> _logger;

        public UseCaseDemoTransient(IGuidServiceTransient guidService, ILogger<UseCaseDemoTransient> logger)
        {
            _guidService = guidService;
            _logger = logger;
        }

        public Guid GetGuid()
        {
           return _guidService.GetGuid();
        }

        public void Dispose()
        {
            _logger.LogInformation("Disposing {0}", nameof(UseCaseDemoTransient));
        }
    }
}
