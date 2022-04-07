using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Purchasing;

namespace Purchasing
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

		public string Test(){
			return "Hello from Purchasing Services";
		}
	}
}
