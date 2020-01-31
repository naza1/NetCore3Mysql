using System.ComponentModel.DataAnnotations;
using Entities;

namespace Registration_Login_Api.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int SpaId { get; set; }
    }
}
