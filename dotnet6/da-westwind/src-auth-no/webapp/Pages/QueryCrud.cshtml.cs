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
					FilterType = "PartialString";
					GetProducts(FilterType);
					SuccessMessage = "Search By Partial Product Name Successful";
				}
				else if(ButtonPressed == "SearchByCategory")
				{
					FilterType = "DropDown";
					GetProducts(FilterType);
					SuccessMessage = "Search By Category Successful";
				}
				else if(ButtonPressed == "Update")
				{
					if(string.IsNullOrEmpty(Product.ProductName))
							throw new ArgumentException("ProductName cannot be empty");
					if(Product.SupplierId == 0)
							throw new ArgumentException("SupplierId cannot be 0");
					if(Product.CategoryId == 0)
							throw new ArgumentException("CategoryId cannot be 0");
					if(string.IsNullOrEmpty(Product.QuantityPerUnit))
							throw new ArgumentException("QuantityPerUnit cannot be empty");
					Services.Edit(Product);
					SuccessMessage = "Update Successful";
				}
				else if(ButtonPressed == "Add")
				{
					if(string.IsNullOrEmpty(Product.ProductName))
							throw new ArgumentException("ProductName cannot be empty");
					if(Product.SupplierId == 0)
							throw new ArgumentException("SupplierId cannot be 0");
					if(Product.CategoryId == 0)
							throw new ArgumentException("CategoryId cannot be 0");
					if(string.IsNullOrEmpty(Product.QuantityPerUnit))
							throw new ArgumentException("QuantityPerUnit cannot be empty");
					Services.Add(Product);
					SuccessMessage = "Add Successful";
				}
				else if(ButtonPressed == "Delete")
				{
					Services.Delete(Product);
					Product = new Product();
					SuccessMessage = "Delete Successful";
				}
				else if(Product.ProductId != 0)
				{
						Product = Services.Retrieve(Product.ProductId);
						SuccessMessage = "Retrieve Successful";
				}
				else 
				{
					Console.WriteLine("you must have pressed an Edit");
					// Console.WriteLine(ProductId);
					// Product.ProductId = ProductId;
					// Console.WriteLine(Product.ProductId);
				}
				PopulateSelectList();
				GetProducts(FilterType);
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

