using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Entities;
using DAL;

namespace BLL 
{
    public class OtherServices 
    {
        private readonly Context Context;
        public  OtherServices(Context context) 
        {
            if (context == null)
                throw new ArgumentNullException();
            Context = context;
        }

        #region QUERY
        
        // public List<Product> FindProductsByPartialProductName(string partialProductName)
        // {
        //     Console.WriteLine($"WestWindServices: FindProductsByPartialProductName(); partialProductName= {partialProductName}");
        //     return Context.Products.Where(x=>x.ProductName.Contains(partialProductName))
        //                            .OrderBy(x => x.ProductName).ToList();
        // }   
        #endregion
        
        // #region READ - Edit, Add, Delete
        // public void Edit(Product item)
        // {
        //     Console.WriteLine($"WestWindServices: Edit; productId = {item.ProductId}");
        //     var existing = Context.Entry(item);
        //     existing.State = EntityState.Modified;
        //     Context.SaveChanges();
        // }
        // public void Add(Product item)
        // {
        //     Console.WriteLine($"WestWindServices: Add; productId= {item.ProductId}");
        //     Context.Products.Add(item);
        //     Context.SaveChanges();
        // }
        // public void Delete(Product item)
        // {
        //     Console.WriteLine($"WestWindServices: Delete; productId= {item.ProductId}");
        //     var existing = Context.Entry(item);
        //     existing.State = EntityState.Deleted;
        //     Context.SaveChanges();
        // }
        // #endregion
    }
}



// List<ProgramCourse> SearchedRecords = Context.ProgramCourses.Where(x => x.ProgramId == item.ProgramId).ToList();
            // if(SearchedRecords.Count != 0)
            //     throw new Exception("Cannot delete a program that has a course");