using DependencyInjectionDemonstration.API.Services;

namespace DependencyInjectionDemonstration.API.UseCases
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
