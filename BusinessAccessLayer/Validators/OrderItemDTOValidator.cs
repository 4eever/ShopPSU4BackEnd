using BusinessAccessLayer.DTOs;
using FluentValidation;

namespace BusinessAccessLayer.Validators
{
    public class OrderItemDTOValidator : AbstractValidator<OrderItemDTO>
    {
        public OrderItemDTOValidator()
        {
            RuleFor(item => item.ProductQuantity)
                .NotEmpty().WithMessage(ValidatorConst.emptyErrorMessage);

        }
    }
}
