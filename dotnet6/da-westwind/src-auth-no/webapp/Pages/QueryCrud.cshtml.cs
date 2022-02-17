using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

//Additional namespaces
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

		public string SuccessMessage { get; set; }
		public string ErrorMessage { get; set; }
		public List<Exception> Errors {get; set;} = new();
		[BindProperty]
		public string ButtonPressed {get; set;}
		[BindProperty]
		public string FilterType {get;set;}
		[BindProperty]
		public string PartialProductName {get;set;}
		[BindProperty]
		public int? SelectedCategoryId {get;set;}
		[BindProperty]
		public List<Product> SearchedProducts { get; set; }
		[BindProperty]
		public Product Product {get;set;} = new();
		[BindProperty]
		public string Discontinued {get;set;} 

		[BindProperty]
		public List<Category> SelectListOfCatagories {get;set;}
		[BindProperty]
		public List<Supplier> SelectListOfSuppliers {get;set;}
		
		public IActionResult OnGet()
		{
			try
			{
				Console.WriteLine("QueryModel: OnGet");
				PopulateSelectLists();
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
					FilterType = "PartialString";
				}
				else if(ButtonPressed == "SearchByCategory")
				{
					FilterType = "DropDown";
				}
				else if(ButtonPressed == "Update")
				{
					if(Discontinued == "on")
						Product.Discontinued = true;
					else
						Product.Discontinued = false;
					FormValidation();
					Services.Edit(Product);
					SuccessMessage = "Update Successful";
				}
				else if(ButtonPressed == "Add")
				{
					if(Discontinued == "on")
						Product.Discontinued = true;
					else
						Product.Discontinued = false;
					FormValidation();
					Services.Add(Product);
					SuccessMessage = "Add Successful";
				}
				else if(ButtonPressed == "Delete")
				{
					Services.Delete(Product);
					Product = new Product();
					SuccessMessage = "Delete Successful";
				}
				else if(ButtonPressed == "Clear")
				{
					Product = new Product();
					SuccessMessage = "Clear Successful";
				}
				else if(Product.ProductId != 0)
				{
						Product = Services.Retrieve(Product.ProductId);
						SuccessMessage = "Product Retrieve Successful";
				}
				else 
				{
					SuccessMessage = "What just happened";
				}
			}
			catch (AggregateException ex)
			{
				ErrorMessage = ex.Message;
			}
			catch (Exception ex)
			{
				ErrorMessage = GetInnerException(ex);
			}
			PopulateSelectLists();
			GetProducts(FilterType);
			return Page();
			
		}

		private void PopulateSelectLists()
		{
			try
			{
				Console.WriteLine("Querymodel: PopulateSelectLists");
				SelectListOfCatagories = Services.ListCategories();
				SelectListOfSuppliers = Services.ListSuppliers();
			}
			catch (Exception ex)
			{ 
				ErrorMessage = GetInnerException(ex);
			}
		}

		private void GetProducts(string filterType)
		{
			try
			{
				Console.WriteLine($"QueryCrudModel: GetProducts:filtertype= {filterType}");
				if(filterType == "PartialString")
					SearchedProducts = Services.FindProductsByPartialProductName(PartialProductName);
				else if(filterType == "DropDown")
					SearchedProducts = Services.FindProductsByCategory(SelectedCategoryId);
			}
			catch (Exception ex)
			{ 
				ErrorMessage = GetInnerException(ex);
			}
		}

		public void FormValidation()
		{
			if(string.IsNullOrEmpty(Product.ProductName))
				Errors.Add(new Exception("ProductName"));
			if(Product.SupplierId == 0)
				Errors.Add(new Exception("SupplierId"));
			if(Product.CategoryId == 0)
				Errors.Add(new Exception("CategoryId"));
			if(string.IsNullOrEmpty(Product.QuantityPerUnit))
				Errors.Add(new Exception("QuantityPerUnit"));
			
			if (Errors.Count() > 0)
					throw new AggregateException("Invalid Data: ", Errors);
		}

		public string GetInnerException(Exception e)
		{
			Exception rootCause = e;
			while (rootCause.InnerException != null)
					rootCause = rootCause.InnerException;
			return rootCause.Message;
		}
	}
}

