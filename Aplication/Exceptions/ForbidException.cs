﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadDesigner.Aplication.Exceptions
{
    public class ForbidException : System.Exception
    {
        public ForbidException(string? message) : base(message)
        {
        }
    }
}
