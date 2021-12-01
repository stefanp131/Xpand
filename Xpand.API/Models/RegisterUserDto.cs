using System.ComponentModel.DataAnnotations;

namespace Xpand.API.Models
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }
        [EmailAddress]  
        [Required(ErrorMessage = "Email is required")]  
        public string Email { get; set; } 
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "RobotsCrew is required")]
        public string RobotsCrew { get; set; }
    }
}