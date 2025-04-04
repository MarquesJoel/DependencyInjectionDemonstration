using DependencyInjectionDemonstration.API.Services;
using DependencyInjectionDemonstration.API.UseCases;

namespace DependencyInjectionDemonstration.API.RegistersInjection
{
    public static class ExtensionDI
    {
        public static IServiceCollection RegisterDenpendencyInjections(this IServiceCollection services)
        {
            //Scoped
            services.AddScoped<IGuidServiceScoped, GuidService>();
            services.AddScoped<IUseCaseDemoSoped, UseCaseDemoSoped>();

            //Transient
            services.AddTransient<IGuidServiceTransient, GuidService>();
            services.AddTransient<IUseCaseDemoTransient, UseCaseDemoTransient>();


            return services;
        }
    }
}
