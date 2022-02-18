using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Additional Namespaces
using DAL;
using Entities;
using ViewModels;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BLL
{
	public class ProductServices
	{
		#region Constructor Dependency Injection
		private readonly Context Context;
		public ProductServices(Context context)
		{
			if (context == null)
				throw new ArgumentNullException();
			Context = context;
		}
		#endregion

		#region Queries
		public List<ProductList> FindProductsByPartialName(string partialName)
		{
			Console.WriteLine($"ProductServices: FindProductsByPartialName(); partialName= {partialName}");
			var info =
				Context.Products
				.Where(x => x.ProductName.Contains(partialName))
				.Select(x => new ProductList
				{
					ProductId = x.ProductId,
					ProductName = x.ProductName,
					Supplier = x.Supplier.CompanyName,
					Category = x.Category.CategoryName,
					QuantityPerUnit = x.QuantityPerUnit,
					MinimumOrderQuantity = x.MinimumOrderQuantity,
					UnitPrice = x.UnitPrice,
					UnitsOnOrder = x.UnitsOnOrder,
					Discontinued = x.Discontinued
				})
				.OrderBy(x => x.ProductName);
			return info.ToList();
		}   

		public List<ProductList> FindProductsByCategory(int? id)
		{
			Console.WriteLine($"ProductServices: FindProductsByCategory(); id= {id}");
			var info = 
				Context.Products
				.Where(x=>x.CategoryId == id)
				.Select(x => new ProductList
				{
					ProductId = x.ProductId,
					ProductName = x.ProductName,
					Supplier = x.Supplier.CompanyName,
					Category = x.Category.CategoryName,
					QuantityPerUnit = x.QuantityPerUnit,
					MinimumOrderQuantity = x.MinimumOrderQuantity,
					UnitPrice = x.UnitPrice,
					UnitsOnOrder = x.UnitsOnOrder,
					Discontinued = x.Discontinued
				})
				.OrderBy(x => x.ProductName);
			return info.ToList();
		}

		public ProductItem Retrieve(int id)
		{
			var info = 
				Context.Products
				.Where(x => x.ProductId == id)
				.Select(x => new ProductItem
				{
					ProductId = x.ProductId,
					ProductName = x.ProductName,
					SupplierId = x.SupplierId,
					CategoryId = x.CategoryId,
					QuantityPerUnit = x.QuantityPerUnit,
					MinimumOrderQuantity = x.MinimumOrderQuantity,
					UnitPrice = x.UnitPrice,
					UnitsOnOrder = x.UnitsOnOrder,
					Discontinued = x.Discontinued
				}).FirstOrDefault();
			return info;
		}
		#endregion

		#region Edit, Add, Delete
		public void Edit(ProductItem item)
		{
				Console.WriteLine($"ProductServices: Edit; productId = {item.ProductId}");
				var info = Context.Products.Find(item.ProductId);
				if (info == null)
			 		throw new Exception("Product does not exist");
				info.ProductId = item.ProductId;
				info.ProductName = item.ProductName;
				info.SupplierId = item.SupplierId;
				info.CategoryId = item.CategoryId;
				info.QuantityPerUnit = item.QuantityPerUnit;
				info.MinimumOrderQuantity = item.MinimumOrderQuantity;
				info.UnitPrice = item.UnitPrice;
				info.UnitsOnOrder = item.UnitsOnOrder;
				info.Discontinued = item.Discontinued;
				var updating = Context.Entry(info);
				updating.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				Context.SaveChanges();
		}

		// 	return Context.SaveChanges();

		public void Add(ProductItem item)
		{
			Console.WriteLine($"ProductServices: Add; productId= {item.ProductId}");

			var newProduct = new Product();
			newProduct.ProductId = item.ProductId;
			newProduct.ProductName = item.ProductName;
			newProduct.SupplierId = item.SupplierId;
			newProduct.CategoryId = item.CategoryId;
			newProduct.QuantityPerUnit = item.QuantityPerUnit;
			newProduct.MinimumOrderQuantity = item.MinimumOrderQuantity;
			newProduct.UnitPrice = item.UnitPrice;
			newProduct.UnitsOnOrder = item.UnitsOnOrder;
			newProduct.Discontinued = item.Discontinued;
			Context.Products.Add(newProduct);
			Context.SaveChanges();
			//return newProduct.ProductId;
		}



		// public void Delete(Product item)
		// {
		// 		Console.WriteLine($"ProductServices: Delete; productId= {item.ProductId}");
		// 		var existing = Context.Entry(item);
		// 		existing.State = EntityState.Deleted;
		// 		Context.SaveChanges();
		// }
		#endregion

		// public int AddMovie(MovieItem item)
		// {
		// 	var existing = Context.Movies.FirstOrDefault(x => x.Title == item.Title && x.ReleaseYear == item.ReleaseYear && x.Length == item.Length);
		// 	if (existing != null)
		// 		throw new Exception("A movie with the same title, release year, and length already exists");
		// 	#endregion

		// 	Movie movie = new Movie
		// 	{
		// 		Title = item.Title,
		// 		ReleaseYear = item.ReleaseYear,
		// 		RatingId = item.RatingId,
		// 		GenreId = item.GenreId,
		// 		ScreenTypeId = item.ScreenTypeId,
		// 		Length = item.Length
		// 	};
		// 	Context.Movies.Add(movie);
		// 	Context.SaveChanges();
		// 	return movie.MovieId;


		

		// public int RemoveMovie(MovieItem item)
		// {
		// 	#region STUDENT CODE HERE
		// 	//TODO: Business process rule(s)

		// 	Movie exists = Context.Movies.Find(item.MovieId);
		// 	if (exists == null)
		// 		throw new Exception("The movie does not exist");
		// 	#endregion

		// 	EntityEntry<Movie> removing = Context.Entry(exists);
		// 	removing.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
		// 	return Context.SaveChanges();
		// }
	}
}
