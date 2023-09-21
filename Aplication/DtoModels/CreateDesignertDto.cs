using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadDesigner.Aplication.DtoModels
{
    public class CreateDesignertDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public bool HasDelivery { get; set; } 
        public string ContactEmail { get; set; } = default!;
        public string ContactNumber { get; set; } = default!;
        [Required]
        [MaxLength(50)]
        public string City { get; set; } = default!;
        [Required]
        [MaxLength(50)]
        public string Street { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
    }
}



