using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using back_end;

namespace front_end.Pages
{
	public class ListtoListModel : PageModel
	{
		private readonly ListtoListService Service;

		public ListtoListModel(ListtoListService service)
		{
			Service = service;
		}

		public string SuccessMessage { get; set; }
		public string ErrorMessage { get; set; }
		public List<Exception> Errors {get; set;} = new();

		[BindProperty]
		public List<NamedColor> AvailableColors { get; set; }
		[BindProperty]
		public List<NamedColor> ColorPallete { get; set; }
		
		[BindProperty]
		public string SelectedAddColor {get;set;}
		[BindProperty]
		public string SelectedRemoveColor {get;set;}

		public IActionResult OnGet()
		{
			try
			{
				Console.WriteLine("ListtoListModel: OnGet");
				AvailableColors = Service.ListHTMLColors();
				ColorPallete = new List<NamedColor>();
			}
			catch (Exception ex)
			{
				ErrorMessage = GetInnerException(ex);
			}
			return Page();
		}

		public IActionResult OnPost()
		{
			try
			{
				Console.WriteLine("ListtoListModel: OnPost");
				
				foreach (var item in AvailableColors)
				{
					Console.WriteLine($"Available.item.Name = {item.Name}");
				}
				foreach (var item in ColorPallete)
				{
					Console.WriteLine($"ColorPallete.item.Name = {item.Name}");
				}

				if(SelectedAddColor != null)
				{
					Console.WriteLine($"Add button pressed");
					Console.WriteLine($"SelectedAddColor = {SelectedAddColor}");
					var found = AvailableColors.SingleOrDefault(x => x.Name == SelectedAddColor);
					if (found != null)
					{
						Console.WriteLine($"found NOT null");
						AvailableColors.Remove(found);
						ColorPallete.Add(found);
					}
					else
					{
						Console.WriteLine($"found IS null");
					}
					SuccessMessage = "Add Successful";
				}
				else if(SelectedRemoveColor != null)
				{
					Console.WriteLine($"Remove button pressed");
					Console.WriteLine($"SelectedRemoveColor = {SelectedRemoveColor}");
					var found = ColorPallete.SingleOrDefault(x => x.Name == SelectedRemoveColor);
					if (found != null)
					{
						AvailableColors.Add(found);
						ColorPallete.Remove(found);
					}
					SuccessMessage = "Remove Successful";
				}
				else 
				{
					ErrorMessage = "Danger: At the end of our ropes!";
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
			return Page();
			
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
