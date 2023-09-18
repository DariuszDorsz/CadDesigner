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
        public int Price { get; set; }

        public int DesignerId { get; set; }
        public virtual DesigneOffice DesigneOffice { get; set; } = default!;
    }
}
