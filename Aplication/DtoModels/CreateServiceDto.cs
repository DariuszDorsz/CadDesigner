using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadDesigner.Aplication.DtoModels
{
   public class CreateServiceDto
    {
      
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }

        public int RestaurantId { get; set; }
    }
}
