using BusinessAccessLayer.DTOs;
using FluentValidation;

namespace BusinessAccessLayer.Validators
{
    public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(prod => prod.ProductName)
                .NotEmpty().WithMessage(ValidatorConst.emptyErrorMessage)
                .Matches("^[a-zA-Zа-яА-Я0-9,.-]+$").WithMessage("First Name field should contain only letters and numbers (against \"-\", \",\", \".\").");

            RuleFor(prod => prod.ProductDescription)
                .NotEmpty().WithMessage(ValidatorConst.emptyErrorMessage);

            RuleFor(prod => prod.ProductPrice)
                .NotEmpty().WithMessage(ValidatorConst.emptyErrorMessage)
                .GreaterThan(0).WithMessage("Price should be greater than zero");
        }
    }
}
