using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Security;

namespace Security
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

		public List<IIdentifyEmployee> ListEmployees()
		{
			var people = from emp in Context.Employees
										select new StaffMember
										{
												EmployeeId = emp.EmployeeId,
												Email = $"{emp.FirstName}.{emp.LastName}@eBikes.edu.ca",
												// NOTE: UserName as an email to match the default login page
												UserName = $"{emp.FirstName}.{emp.LastName}@eBikes.edu.ca",
												//UserName = $"{emp.FirstName}.{emp.LastName}" // Alternative
										};
			return people.ToList<IIdentifyEmployee>();
		}

		public string GetEmployeeName(int employeeId)
		{
			string result = "";
			var found = Context.Employees.Find(employeeId);
			if (found != null)
					result = $"{found.FirstName} {found.LastName}";
			return result;
		}
		
	}
}
