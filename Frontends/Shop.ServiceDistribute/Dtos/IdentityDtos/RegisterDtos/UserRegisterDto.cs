using System.ComponentModel.DataAnnotations;

namespace Shop.ServiceDistribute.Dtos.IdentityDtos.RegisterDtos
{
    public class UserRegisterDto
    {
		[Required(ErrorMessage = "Adınız gereklidir.")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Soyadınız gereklidir.")]
		public string Surname { get; set; }

		[Required(ErrorMessage = "Email adresiniz gereklidir.")]
		[EmailAddress(ErrorMessage = "Geçersiz email adresi.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Şifre gereklidir.")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Tekrar şifre gereklidir.")]
		[Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
		public string ConfirmPassword { get; set; }

	}
}
