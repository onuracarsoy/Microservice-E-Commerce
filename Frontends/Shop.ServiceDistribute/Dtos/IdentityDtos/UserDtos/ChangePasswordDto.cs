using System.ComponentModel.DataAnnotations;

namespace Shop.ServiceDistribute.Dtos.IdentityDtos.UserDtos
{
    public class ChangePasswordDto
    {

        public string CurrentPassword { get; set; }

  
        public string NewPassword { get; set; }
    }
}
