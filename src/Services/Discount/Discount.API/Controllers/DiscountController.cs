using Discount.API.Entities;
using Discount.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Discount.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountRepository _repository;

        public DiscountController(IDiscountRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Coupon>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Coupon>>> GetAllDiscount()
        {
            var discounts = await _repository.GetAllDiscount();

            return Ok(discounts);
        }

        [HttpGet("{productName}", Name = "GetDiscount")]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> GetDiscount(string productName)
        {
            var discount = await _repository.GetDiscount(productName);

            return Ok(discount);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Coupon>> CreateDiscount([FromBody]Coupon discount)
        {
            var newDiscount = await _repository.CreateDiscount(discount);

            return CreatedAtAction(nameof(GetDiscount), new { productname = discount.ProductName}, newDiscount);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.NoContent)]
        public async Task<ActionResult<Coupon>> UpdateDiscount([FromBody] Coupon discount)
        {
            var newDiscount = await _repository.UpdateDiscount(discount);

            return CreatedAtAction(nameof(GetDiscount), new { productname = discount.ProductName }, newDiscount);
        }

        [HttpDelete("{productName}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.NoContent)]
        public async Task<ActionResult<bool>> DeleteDiscount(string productName)
        {
           return await _repository.DeleteDiscount(productName);
        }
    }
}
