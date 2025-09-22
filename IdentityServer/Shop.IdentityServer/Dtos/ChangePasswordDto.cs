using System.ComponentModel.DataAnnotations;

namespace Shop.IdentityServer.Dtos
{
    public class ChangePasswordDto
    {

        public string CurrentPassword { get; set; }

  
        public string NewPassword { get; set; }
    }
}
