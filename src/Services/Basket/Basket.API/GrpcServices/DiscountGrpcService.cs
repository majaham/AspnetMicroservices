using Discount.Grpc.Protos;
using System;
using System.Threading.Tasks;
using static Discount.Grpc.Protos.DiscountProtoService;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoServiceClient _discountClient;

        public DiscountGrpcService(DiscountProtoServiceClient discountClient)
        {
            _discountClient = discountClient ?? throw new ArgumentNullException(nameof(discountClient));
        }

        public async Task<CouponModel> GetDiscount(string productname)
        {
            var discountRequest = new DiscountRequest { ProductName = productname };

            return await _discountClient.GetDiscountAsync(discountRequest);
        }
    }
}
