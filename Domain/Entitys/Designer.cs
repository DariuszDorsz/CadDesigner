using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadDesigner.Domain.Entitys
{
    public class Designer
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public string ContactEmail { get; set; } = default!;
        public string ContactNumber { get; set; } = default!;



        public int CreatedById { get; set; }
        public virtual User CreatedBy { get; set; } = default!;

        public int AddressId { get; set; }
        public virtual Address Address { get; set; } = default!;

        public virtual List<Service> Services { get; set; } = new();
    }
}
