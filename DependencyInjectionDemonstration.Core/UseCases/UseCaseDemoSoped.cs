using DependencyInjectionDemonstration.Core.Services;
using Microsoft.Extensions.Logging;

namespace DependencyInjectionDemonstration.Core.UseCases
{

    public class UseCaseDemoSoped: IUseCaseDemoSoped, IDisposable
    {
        private readonly IGuidServiceScoped _guidService;

        private readonly ILogger<UseCaseDemoSoped> _logger;

        public UseCaseDemoSoped(IGuidServiceScoped guidService, ILogger<UseCaseDemoSoped> logger)
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
            _logger.LogInformation("Disposing {0}", nameof(UseCaseDemoSoped));
        }
    }
}
