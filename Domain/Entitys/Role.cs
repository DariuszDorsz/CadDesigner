using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadDesigner.Domain.Entitys
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public IEnumerable<User> Users { get; set; } = default!;
    }
}
