using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadDesigner.Domain.Entitys
{
    public class User
    {
        public int Id { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public DateTime? DateOfBirth { get; set; } = default!;
        public string Nationality { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public Role Role { get; set; } = default!;
        public int RoleId { get; set; } = default!;
    }
}
