﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CadDesigner.Aplication.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAplication(this IServiceCollection service)
        {
            Console.WriteLine("DDD");
        }
    }
}
