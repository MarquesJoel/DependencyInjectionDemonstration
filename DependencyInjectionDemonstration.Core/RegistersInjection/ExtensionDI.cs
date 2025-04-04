using DependencyInjectionDemonstration.Core.Services;
using DependencyInjectionDemonstration.Core.UseCases;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DependencyInjectionDemonstration.Core.RegistersInjection
{
    public static class ExtensionDI
    {
        public static IServiceCollection RegisterDenpendencyInjections(this IServiceCollection services)
        {
            //Scoped
            services.AddScoped<IGuidServiceScoped, GuidServiceScoped>();
            //services.AddScoped<IUseCaseDemoSoped, UseCaseDemoSoped>();
            services.AddScoped<IUseCaseDemoSoped>(services => new UseCaseDemoSoped(services.GetRequiredService<IGuidServiceScoped>(), services.GetRequiredService<ILogger<UseCaseDemoSoped>>()));

            //Transient
            services.AddTransient<IGuidServiceTransient, GuidServiceTranisent>();
            services.AddTransient<IUseCaseDemoTransient, UseCaseDemoTransient>();


            return services;
        }
    }
}
