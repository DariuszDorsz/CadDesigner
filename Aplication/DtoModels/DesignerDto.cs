using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadDesigner.Aplication.DtoModels
{
    public class DesignerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string PostalCode { get; set; } = default!;

        public List<ServiceDto> Services { get; set; } = new();
    }
}
