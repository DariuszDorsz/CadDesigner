using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadDesigner.Domain.Models
{
    public class DesignerQuery
    {
        public string? SearchPhrase { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public string SortBy { get; set; } = "Name";
        public SortDirection SortDirection { get; set; } = SortDirection.ASC;
    }
}
