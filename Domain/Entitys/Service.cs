using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadDesigner.Domain.Entitys
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int Price { get; set; } = default!;
        public int DesignerId { get; set; } = default!;
        public virtual Designer DesigneOffice { get; set; } = default!;
    }
}
