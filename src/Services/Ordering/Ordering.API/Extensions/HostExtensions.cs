using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace Ordering.API.Extensions
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase<TContext>(this IHost host, Action<TContext, IServiceProvider> seeder, int? retry = 0)
            where TContext: DbContext
         {
            int retryForAvailability = retry.Value;
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILogger<TContext>>();
            var context = services.GetService<TContext>();

            try
            {
                logger.LogInformation("Database migration started for context {dbContext}", context);
                InvokeSeeder(seeder, context, services);
                logger.LogInformation("Database migration completed for context {dbContext}", context);
            }
            catch (SqlException ex)
            {
                logger.LogError(ex, "Error occured while migrating database");
                if(retryForAvailability < 20)
                {
                    retryForAvailability++;
                    System.Threading.Thread.Sleep(2000);
                    MigrateDatabase<TContext>(host, seeder, retryForAvailability);
                }
            }

            return host;
         }

        private static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider> seeder, TContext context, IServiceProvider services) 
            where TContext : DbContext
        {
            context.Database.Migrate();
            seeder(context, services);           
        }
    }
}
