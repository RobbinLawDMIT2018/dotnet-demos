using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Purchasing;

namespace webapp.Pages.ManagePurchasing
{
    public class ManagePurchasingModel : PageModel
    {
        #region Private variables and DI constructor
		private readonly Services Services;
		
		public ManagePurchasingModel(Services services)
		{
			Services = services;
		}
		#endregion

        public string SuccessMessage { get; set; }
		public string ErrorMessage { get; set; }
		public List<Exception> Errors {get; set;} = new();


        public void OnGet()
        {
            SuccessMessage = Services.Test();
        }
    }
}