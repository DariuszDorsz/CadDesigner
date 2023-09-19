using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadDesigner.Aplication.Exceptions
{
    public class BadRequestException : System.Exception
    {
        public BadRequestException(string? message) : base(message)
        {
        }
    }
}
