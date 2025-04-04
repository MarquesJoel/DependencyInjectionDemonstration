using DependencyInjectionDemonstration.API.Services;

namespace DependencyInjectionDemonstration.API.UseCases
{

    public class UseCaseDemoTransient: IUseCaseDemoTransient
    {
        private readonly IGuidServiceScoped _guidService;

        public UseCaseDemoTransient(IGuidServiceTransient guidService)
        {
            _guidService = guidService;
        }

        public Guid GetGuid()
        {
           return _guidService.GetGuid();
        }
    }
}
