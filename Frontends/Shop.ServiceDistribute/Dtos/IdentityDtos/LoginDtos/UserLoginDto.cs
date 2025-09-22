using System.ComponentModel.DataAnnotations;

namespace Shop.ServiceDistribute.Dtos.IdentityDtos.LoginDtos
{
	public class UserLoginDto
	{
		[Required(ErrorMessage = "Email adresiniz gereklidir.")]
		[EmailAddress(ErrorMessage = "Geçersiz email adresi.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Şifre gereklidir.")]
		public string Password { get; set; }
	}
}
