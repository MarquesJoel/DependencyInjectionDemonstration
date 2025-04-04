using Microsoft.Extensions.Logging;

namespace DependencyInjectionDemonstration.Core.Services
{
    public class GuidServiceTranisent: IGuidServiceTransient, IDisposable
    {
        private readonly Guid _guid;
        private readonly ILogger<GuidServiceTranisent> _logger;

        public GuidServiceTranisent(ILogger<GuidServiceTranisent> logger)
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
            _logger.LogInformation("Disposing {0}", nameof(GuidServiceTranisent));
        }

    }
}
