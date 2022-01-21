<Query Kind="Expression">
  <Connection>
    <ID>6250ae22-791d-450a-bb2b-1d1c0436a610</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <Server>.</Server>
    <Database>WestWind</Database>
    <DisplayName>WestWindEntity</DisplayName>
    <DriverData>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
</Query>

// 14
// Lookup the category names, in alphabetical order
Categories
.OrderBy (row => row.CategoryName)
.Select (row => row.CategoryName)

// List all the product and category names 
// using nav properties to get CategoryName
Products
.Select (data => new 
{
Product = data.ProductName,
Category = data.Category.CategoryName
})


// Get the products displaying the product name, the category, and the unit price. 
// Sort the results alphabetically by category and then in descending order by unit price.
// Use nav properties to get CategoryName
Products
.OrderBy (item => item.Category.CategoryName)
.ThenByDescending (item => item.UnitPrice)
.Select (item => new 
{
Product = item.ProductName,
Category = item.Category.CategoryName,
Price = item.UnitPrice
})


// Look up the Employees, sorted by last name then first name. Show the first and last name separately
Employees
.OrderBy (person => person.LastName)
.ThenBy (person => person.FirstName)
.Select (person => new 
{
FirstName = person.FirstName,
LastName = person.LastName
})

// - Filter on partial name
// List employees who have an "an" in their first name
Employees
.Where (person => person.FirstName.Contains ("an"))

// List the full name of all the employees who look after 7 or more territories
Employees
.Where (person => (person.EmployeeTerritories.Count >= 7))
.Select (person => ((person.FirstName + " ") + person.LastName))

// List the first and last name of all the employees who look after 7 or more territories
// as well as the names of all the territories they are responsible for.
// Use nav properties to get EmployeeTerritories.
Employees
.Where (person => (person.EmployeeTerritories.Count >= 7))
.Select (person => new 
{
First = person.FirstName,
Last = person.LastName,
Territories = person.EmployeeTerritories.Select (place => place.Territory.TerritoryDescription)
})

// List all the employees who do not have a manager
// (i.e.: they do not report to anyone).
Employees
.Where (person => (person.ReportsToEmployee == null))
.Select (person => new 
{
Name = ((person.FirstName + " ") + person.LastName),
JobTitle = person.JobTitle,
Age = ((DateTime.Now - person.BirthDate).Days / 365),
Address = person.Address
})

// List all the employees full names who do not manage anyone.
Employees
.Where (person => (person.ReportsToChildren.Count == 0))
.Select (person => new 
{
Name = ((person.FirstName + " ") + person.LastName),
JobTitle = person.JobTitle
})

// List all the employees full names who are managers and their subordinates.
Employees
.Where (person => (person.ReportsToChildren.Count > 0))
.Select (person => new 
{
Name = ((person.FirstName + " ") + person.LastName),
JobTitle = person.JobTitle,
Subordinates = 	person.ReportsToChildren
				.Select (emp => new 
				{
				GivenName = emp.FirstName,
				Surname = emp.LastName
				})
})

// List all the customers and the name, qty, unit price and the subtotal of each
// of the items they purchased.
Customers
.Select (data => new 
{
CompanyName = data.CompanyName,
Sales = data.Orders.SelectMany (purchase => purchase.OrderDetails, (purchase, lineItem) => new 
         {
            Name = lineItem.Product.ProductName,
            Qty = lineItem.Quantity,
            UnitPrice = lineItem.UnitPrice,
            SubTotal = (lineItem.UnitPrice * (Decimal)(lineItem.Quantity))
         })
})



