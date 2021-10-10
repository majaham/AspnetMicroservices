using AutoMapper;
using Discount.Grpc.Entities;
using Discount.Grpc.Protos;
using Discount.Grpc.Repositories;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using static Discount.Grpc.Protos.DiscountProtoService;

namespace Discount.Grpc.Services
{
    public class DiscountService: DiscountProtoServiceBase
    {
        private readonly IDiscountRepository _repository;
        private readonly ILogger<DiscountService> _logger;
        private readonly IMapper _mapper;

        public DiscountService(IDiscountRepository repository, ILogger<DiscountService> logger, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public override async Task<CouponModel> GetDiscount(DiscountRequest request, ServerCallContext context)
        {
            var coupon = await _repository.GetDiscount(request.ProductName);

            if(coupon == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound,
                                       $"Discount for product {request.ProductName} not found."));
            }
            _logger.LogInformation($"Discount for product: {coupon.ProductName}, discount amount: {coupon.Amount} found");

            var couponModel = _mapper.Map<CouponModel>(coupon);

            return couponModel; 
        }

        public override async Task<CouponModel> CreateDiscount(CouponModel request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request);
            var newCoupon = await _repository.CreateDiscount(coupon);

            _logger.LogInformation("Discount successfully created for {ProductName}", newCoupon.ProductName);

            var couponModel = _mapper.Map<CouponModel>(newCoupon);

            return couponModel;
        }

        public override async Task<CouponModel> UpdateDiscount(CouponModel request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request);
            var newCoupon = await _repository.UpdateDiscount(coupon);

            _logger.LogInformation("Discount successfully updated for {ProductName}", newCoupon.ProductName);

            var couponModel = _mapper.Map<CouponModel>(newCoupon);

            return couponModel;
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DiscountRequest request, ServerCallContext context)
        {
            var isSuccess = await _repository.DeleteDiscount(request.ProductName);

            _logger.LogInformation("Discount for {ProductName} has been removed", request.ProductName);

            var response = new DeleteDiscountResponse { IsSuccess = isSuccess };

            return response;
        }
    }
}
