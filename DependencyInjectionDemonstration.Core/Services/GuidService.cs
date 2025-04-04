namespace DependencyInjectionDemonstration.Worker.Services
{
    public class GuidService: IGuidServiceTransient, IDisposable
    {
        private readonly Guid _guid;

        public GuidService()
        {
            _guid = Guid.NewGuid();
        }

        public Guid GetGuid() 
        {
            return _guid;
        }

        public void Dispose()
        {
            
        }

    }
}
