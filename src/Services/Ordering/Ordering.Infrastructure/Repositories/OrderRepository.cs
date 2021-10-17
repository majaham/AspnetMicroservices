using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts.Persistance;
using Ordering.Domain.Entities;
using Ordering.Infrastructure.Persistance;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private readonly OrderContext _dbContext;

        public OrderRepository(OrderContext orderContext) : base(orderContext)
        {
            _dbContext = orderContext;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUsername(string username)
        {
            var orderList = await _dbContext.Orders
                                   .Where(o => o.UserName == username)
                                   .ToListAsync();
            return orderList;
        }
    }
}
