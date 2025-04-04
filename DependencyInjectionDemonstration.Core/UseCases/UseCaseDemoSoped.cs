using DependencyInjectionDemonstration.Worker.Services;

namespace DependencyInjectionDemonstration.Worker.UseCases
{

    public class UseCaseDemoSoped: IUseCaseDemoSoped
    {
        private readonly IGuidServiceScoped _guidService;

        public UseCaseDemoSoped(IGuidServiceScoped guidService)
        {
            _guidService = guidService;
        }

        public Guid GetGuid()
        {
           return _guidService.GetGuid();
        }
    }
}
