using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ordering.API.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Infrastructure.Persistance;

namespace Ordering.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.MigrateDatabase<OrderContext>((context, services) =>
           {
               var logger = services.GetService<ILogger<OrderContextSeed>>();
               OrderContextSeed.OrderDataSeed(context, logger).Wait();
           });

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
