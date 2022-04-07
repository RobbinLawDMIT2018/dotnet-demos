using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using About;

namespace webApp.Pages.About
{
    public class AboutModel : PageModel
    {
        #region Private variables and DI constructor
		private readonly Services Services;
		
		public AboutModel(Services services)
		{
			Services = services;
		}
		#endregion

        public string SuccessMessage { get; set; }
		public string ErrorMessage { get; set; }
		public List<Exception> Errors {get; set;} = new();

        public BuildVersion DatabaseVersion { get; set; }

        public void OnGet()
        {
            try
            {
                Console.WriteLine($"AboutModel: OnGet");
                DatabaseVersion = Services.GetDbVersion();
                SuccessMessage = $"Database Retrieve Successful";
            }
            catch (Exception ex)
            {
                ErrorMessage = GetInnerException(ex);
            }
            
        }

        public string GetInnerException(Exception ex)
        {
            Exception rootCause = ex;
            while (rootCause.InnerException != null)
                rootCause = rootCause.InnerException;
            return rootCause.Message;
        }
    }
}

