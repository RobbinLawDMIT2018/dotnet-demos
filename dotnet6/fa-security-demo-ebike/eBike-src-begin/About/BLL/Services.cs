using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using About;

namespace About
{
	public class Services
	{
		private readonly Context Context;

		public Services(Context context)
		{
			if (context == null)
				throw new ArgumentNullException();
			Context = context;
		}

		public BuildVersion GetDbVersion() 
        {
            Console.WriteLine($"DbServices: GetDbVersion;");
            var result = Context.BuildVersions.ToList();
            return result.First();
        }
				
		public string Test(){
			return "Hello from About Services";
		}
	}
}
