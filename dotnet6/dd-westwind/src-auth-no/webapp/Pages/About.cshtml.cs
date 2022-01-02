using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using BLL;

namespace MyApp.Namespace
{
    public class AboutModel : PageModel
    {
        //a dependency on the WestWindServices class via "Constructor Dependency Injection"
        private readonly DbServices Services;
        public AboutModel(DbServices services) {
           Services = services;
        }

        public BuildVersion DatabaseVersion { get; set; }

        public string SuccessMessage {get; set;}
        public string ErrorMessage {get; set;}

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
                GetInnerException(ex);
            }
            
        }

        public void GetInnerException(Exception ex)
        {
            Exception rootCause = ex;
            while (rootCause.InnerException != null)
                rootCause = rootCause.InnerException;
            ErrorMessage = rootCause.Message;
        }
    }
}

