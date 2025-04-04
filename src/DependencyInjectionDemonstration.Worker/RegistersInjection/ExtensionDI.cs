using DependencyInjectionDemonstration.Worker.Services;
using DependencyInjectionDemonstration.Worker.UseCases;

namespace DependencyInjectionDemonstration.Worker.RegistersInjection
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
