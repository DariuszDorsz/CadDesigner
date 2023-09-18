using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadDesigner.Domain.Entitys
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime? DateOfBirth { get; set; } 
        public string Nationality { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;

        public int RoleId { get; set; }
        public virtual Role Role { get; set; } = default!;
    }
}
