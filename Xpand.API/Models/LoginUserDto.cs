using System.ComponentModel.DataAnnotations;

namespace Xpand.API.Models
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}