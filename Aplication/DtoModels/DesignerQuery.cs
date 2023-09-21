using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadDesigner.Aplication.DtoModels
{
    public class DesignerQuery
    {
        public string SearchPhrase { get; set; } = default!;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; } = default!;
        public SortDirection SortDirection { get; set; }
    }
}
