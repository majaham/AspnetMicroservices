using Npgsql;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Discount.API.Extensions
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase<TContent>(this IHost host, int? retry = 0)
        {
            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var config = services.GetRequiredService<IConfiguration>();
                var logger = services.GetRequiredService<ILogger<TContent>>();

                int retryForAvailability = retry.Value;

                try
                {
                    logger.LogInformation("Database migration started...");

                    using var connection = new NpgsqlConnection(config.GetConnectionString("DatabaseString"));
                    connection.Open();

                    var cmd = new NpgsqlCommand { Connection = connection };
                    cmd.CommandText = "DROP TABLE IF EXISTS Discount;";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "CREATE TABLE Discount(Id SERIAL PRIMARY KEY," +
                                                           "ProductName VARCHAR(30) NOT NULL, " +
                                                           "Amount REAL, " +
                                                           "Description TEXT);";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO Discount(ProductName, Amount, Description) " +
                                                    "VALUES('IPhone X', 100.00, 'IPhone discount')," +
                                                    "('iMac Book', 150.00, 'iMac Book discount');";
                    cmd.ExecuteNonQuery();

                    logger.LogInformation("Database migration completed");
                }
                catch (NpgsqlException ex)
                {
                    logger.LogError("Database migration errors: " + ex.Message);
                    if(retryForAvailability < 10)
                    {
                        Thread.Sleep(2000);
                        retryForAvailability++;
                        MigrateDatabase<TContent>(host, retryForAvailability);
                    }
                }
            }
            return host;
        }
    }
}
