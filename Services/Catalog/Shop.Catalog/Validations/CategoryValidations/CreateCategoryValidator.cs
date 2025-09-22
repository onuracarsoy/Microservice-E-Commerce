using FluentValidation;
using Shop.Catalog.Dtos.CategoryDtos;

namespace Shop.Catalog.Validations.CategoryValidations
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto> 
    {

        public CreateCategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş geçilemez.");
            RuleFor(x => x.CategoryName).MaximumLength(30).WithMessage("Kategori adı en fazla 30 karakter olabilir.");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Kategori adı en az 2 karakter olabilir.");
            RuleFor(x => x.CategoryImageUrl).NotEmpty().WithMessage("Kategori resmi boş geçilemez.");
        }
    }
}
