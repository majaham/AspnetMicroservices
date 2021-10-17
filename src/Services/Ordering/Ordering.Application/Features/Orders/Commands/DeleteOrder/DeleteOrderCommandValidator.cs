using FluentValidation;

namespace Ordering.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandValidator: AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(o => o.Id)
               .NotEmpty().NotNull().GreaterThan(0).WithMessage("Valid {Id} is required");
        }
    }
}
