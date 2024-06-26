using BusinessAccessLayer.DTOs;
using FluentValidation;

namespace BusinessAccessLayer.Validators
{
    public class CategoryDTOValidator : AbstractValidator<CategoryDTO>
    {
        public CategoryDTOValidator()
        {
            RuleFor(category => category.CategoryName)
                .NotEmpty().WithMessage(ValidatorConst.emptyErrorMessage);

        }
    }
}
