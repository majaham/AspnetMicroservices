using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistance
{
    public class OrderContextSeed
    {
        public static async Task OrderDataSeed(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if(!orderContext.Orders.Any())
            {
                orderContext.AddRange(GetSeedOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
            }           
        }

        private static List<Order> GetSeedOrders()
        {
            return new List<Order>
            {
                new Order() {UserName = "swm", FirstName = "Mehmet", LastName = "Ozkaya", EmailAddress = "ezozkme@gmail.com", AddressLine = "Bahcelievler", Country = "Turkey", TotalPrice = 350 }
            };
        }
    }
}
