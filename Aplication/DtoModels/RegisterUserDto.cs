using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadDesigner.Aplication.DtoModels
{
    public class RegisterUserDto
    {
        [Required]
        public string FirstName { get; set; } = default!;
        [Required]
        public string LastName { get; set; } = default!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = default!;
        [Required]
        [MinLength(6)]
        public string Password { get; set; } = default!;
        [Required]
        public string ConfirmPassword { get; set; } = default!;

        public string Nationality { get; set; } = default!;
        public DateTime? DateOfBirth { get; set; } = default!;
    }
}
