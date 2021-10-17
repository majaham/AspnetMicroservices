﻿using FluentValidation;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidator: AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(o => o.Id)
                .NotEmpty().NotNull().GreaterThan(0).WithMessage("Valid {Id} is required");
            RuleFor(o => o.UserName)
              .NotEmpty().WithMessage("{UserName} is required")
              .NotNull()
              .MaximumLength(50).WithMessage("{UserName} must not exceed 50 characters");

            RuleFor(o => o.EmailAddress)
                .NotEmpty().WithMessage("{EmailAddress} is required")
                .NotNull();

            RuleFor(o => o.TotalPrice)
                .NotEmpty().WithMessage("{TotalPrice} is required")
                .GreaterThan(0).WithMessage("{TotalPrice} must be greater than 0");
        }
    }
}
