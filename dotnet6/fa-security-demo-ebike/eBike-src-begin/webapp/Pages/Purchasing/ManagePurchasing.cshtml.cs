using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Purchasing;

namespace webapp.Pages.ManagePurchasing
{
	public class ManagePurchasingModel : PageModel
	{
		#region Private variables and DI constructor
		private readonly Services Services;
		//private readonly UserManager<ApplicationUser> UserManager;
		//private readonly SecurityService Security;
		
		public ManagePurchasingModel(Services services)
		{
			Services = services;
		}

		// public ManagePurchasingModel(Services services, UserManager<ApplicationUser> userManager, SecurityService security)
		// {
		// 	Services = services;
		// 	UserManager = userManager;
		// 	Security = security;
		// }
		#endregion

		// public ApplicationUser AppUser { get; set; }
		// public string EmployeeName { get; set; }

		public string SuccessMessage { get; set; }
		public string ErrorMessage { get; set; }
		public List<Exception> Errors {get; set;} = new();

		public void OnGet()
		{
			SuccessMessage = Services.Test();
		}

		// public async Task OnGet()
		// {
		// 	AppUser = await UserManager.FindByNameAsync(User.Identity.Name);
		// 	EmployeeName = Security.GetEmployeeName(AppUser.EmployeeId.Value);
		// 	SuccessMessage = Services.Test();
		// }

	}
}