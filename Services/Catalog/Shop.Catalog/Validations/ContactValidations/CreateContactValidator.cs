using FluentValidation;
using Shop.Catalog.Dtos.ContactDtos;

namespace Shop.Catalog.Validations.ContactValidations
{
    public class CreateContactValidator : AbstractValidator<CreateContactDto>
    {
        public CreateContactValidator()
        {
            RuleFor(x => x.ContactNameSurname).NotEmpty().WithMessage("Ad soyad boş geçilemez.");
            RuleFor(x => x.ContactNameSurname).MaximumLength(50).WithMessage("Ad Soyad en fazla 30 karakter olabilir.");
            RuleFor(x => x.ContactNameSurname).MinimumLength(2).WithMessage("Ad Soyad en az 3 karakter olabilir.");

            RuleFor(x => x.ContactSubject).NotEmpty().WithMessage("Konu boş geçilemez.");

            RuleFor(x => x.ContactMessage).NotEmpty().WithMessage("Mesaj boş geçilemez.");

            RuleFor(x => x.ContactSendDate).NotEmpty().WithMessage("Tarih boş geçilemez.");
        }
    }
}
