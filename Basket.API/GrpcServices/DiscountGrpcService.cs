﻿using Discount.gRPC.Protos;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoService;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoService)
        {
            _discountProtoService = discountProtoService ?? throw new ArgumentNullException(nameof(discountProtoService));
        }

        public async Task<CouponModel> GetDiscount(string profuctName)
        {
            var discountRequest = new GetDiscountRequest
            {
                ProductName = profuctName
            };
            return await _discountProtoService.GetDiscountAsync(discountRequest);
        }
    }
}
