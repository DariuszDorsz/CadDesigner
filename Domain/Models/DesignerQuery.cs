using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadDesigner.Domain.Models
{
    public class DesignerQuery
    {
        public string SearchPhrase { get; set; } = default!;
        public int PageNumber { get; set; } = default!;
        public int PageSize { get; set; } = default!;
        public string SortBy { get; set; } = default!;
        public SortDirection SortDirection { get; set; }
    }
}
