using Microsoft.Extensions.Logging;

namespace DependencyInjectionDemonstration.Core.Services
{
    public class GuidServiceScoped: IGuidServiceScoped, IDisposable
    {
        private readonly Guid _guid;

        private readonly ILogger<GuidServiceScoped> _logger;

        public GuidServiceScoped(ILogger<GuidServiceScoped> logger)
        {
            _guid = Guid.NewGuid();
            _logger = logger;
        }

        public Guid GetGuid() 
        {
            return _guid;
        }

        public void Dispose()
        {
            _logger.LogInformation("Disposing {0}", nameof(GuidServiceScoped));
        }

    }
}
