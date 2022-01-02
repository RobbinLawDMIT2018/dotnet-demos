using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Entities;
using DAL;

namespace BLL 
{
    public class DbServices 
    {
        private readonly Context Context;
        public  DbServices(Context context) 
        {
            if (context == null)
                throw new ArgumentNullException();
            Context = context;
        }

        public BuildVersion GetDbVersion() 
        {
            Console.WriteLine($"DbServices: GetDbVersion;");
            var result = Context.BuildVersion.ToList();
            return result.First();
        }
        
    }
}