using DependencyInjectionDemonstration.Worker.RegistersInjection;

namespace DependencyInjectionDemonstration.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            builder.Services.RegisterDenpendencyInjections();

            builder.Services.AddHostedService<Worker>();

            var host = builder.Build();
            host.Run();
        }
    }
}