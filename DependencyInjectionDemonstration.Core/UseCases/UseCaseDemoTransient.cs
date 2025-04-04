using DependencyInjectionDemonstration.Worker.Services;

namespace DependencyInjectionDemonstration.Worker.UseCases
{

    public class UseCaseDemoTransient: IUseCaseDemoTransient
    {
        private readonly IGuidServiceTransient _guidService;

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
