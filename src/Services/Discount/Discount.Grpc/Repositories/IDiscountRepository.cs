using Discount.Grpc.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Discount.Grpc.Repositories
{
    public interface IDiscountRepository
    {
        Task<IEnumerable<Coupon>> GetAllDiscount();

        Task<Coupon> GetDiscount(string productname);

        Task<Coupon> CreateDiscount(Coupon discount);

        Task<Coupon> UpdateDiscount(Coupon discount);

        Task<bool> DeleteDiscount(string productname);
    }
}
