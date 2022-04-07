using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Servicing;

namespace webapp.Pages.ManageServicing
{
    public class ManageServicingModel : PageModel
    {
        #region Private variables and DI constructor
		private readonly Services Services;
		
		public ManageServicingModel(Services services)
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