using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BLL;
using Entities;

namespace MyApp.Namespace
{
    public class QueryCrudModel : PageModel
    {
        private readonly OtherServices Services;
        public QueryCrudModel(OtherServices services)
        {
            Services = services;
        }

        [BindProperty]
        public string ButtonPressed {get; set;}
        [BindProperty]
        public string SuccessMessage { get; set; }
        [BindProperty]
        public string ErrorMessage { get; set; }
        [BindProperty]
        public string PartialProductName {get;set;}
        [BindProperty]
        public int? SelectedCategoryId {get;set;}
        [BindProperty]
        public List<Product> SearchedProducts { get; set; }
        [BindProperty]
        public Product Product {get;set;} = new();
        [BindProperty]
        public int ProductId {get;set;} 

        [BindProperty]
        public List<Category> SelectListOfCatagories {get;set;}
        [BindProperty]
        public List<Supplier> SelectListOfSuppliers {get;set;}
        
        public IActionResult OnGet()
        {
            try
            {
                Console.WriteLine("QueryModel: OnGet");
                PopulateSelectList();
            }
            catch (Exception ex)
            {
                GetInnerException(ex);
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            try
            {
                Console.WriteLine("QueryModel: OnPost");
                if(ButtonPressed == "SearchByPartialProductName")
                {
                    SearchedProducts = Services.FindProductsByPartialProductName(PartialProductName);
                }
                else if(ButtonPressed == "SearchByCategory")
                {
                    SearchedProducts = Services.FindProductsByCategory(SelectedCategoryId);
                }
                else {
                    Console.WriteLine("you must have pressed an Edit");
                    Console.WriteLine(ProductId);
                    Product.ProductId = ProductId;
                    Console.WriteLine(Product.ProductId);
                }
                PopulateSelectList();
            }
            catch (Exception ex)
            {
                GetInnerException(ex);
            }
            return Page();
            
        }

        private void PopulateSelectList()
        {
            try
            {
                Console.WriteLine("Querymodel: PopulateSelectList");
                SelectListOfCatagories = Services.ListCategories();
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

