using BusinessAccessLayer.DTOs;
using FluentValidation;

namespace BusinessAccessLayer.Validators
{
    public class OrderDTOValidator : AbstractValidator<OrderDTO>
    {
        public OrderDTOValidator()
        {

            RuleFor(order => order.OrderDate)
                .NotEmpty().WithMessage(ValidatorConst.emptyErrorMessage)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Date can't be greater then current");

            
        }
    }
}
