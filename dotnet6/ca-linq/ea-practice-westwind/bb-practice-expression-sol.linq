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

//B) Get a list of all the region names
Regions
.Select(place => place.RegionDescription)

//C) Get a list of all the territory names
Territories
.Select(area => area.TerritoryDescription)

//E) List all the region and territory names order by region then territory
Territories
.OrderBy (place => place.Region.RegionDescription)
.ThenBy (place => place.TerritoryDescription)
.Select (place => new 
{
Region = place.Region.RegionDescription,
Territory = place.TerritoryDescription
})

//A) List all the customer company names for those with more than 5 orders.
Customers
.Where (company => (company.Orders.Count > 5))
.Select (company => company.CompanyName)

//D) List all the regions and the number of territories in each region
Regions
.Select (place => new 
{
Region = place.RegionDescription,
NumberOfTerritories = place.Territories.Count
})

//F) List all the region and territory names
//   - use a nested query
Regions
.Select (area => new 
{
Region = area.RegionDescription,
Territories = 	area.Territories
				.Select (place => place.TerritoryDescription)
})

//G) List all the product names that contain the word "chef" in the name.
Products                                              
.Where(item => item.ProductName.Contains("chef")) 
.Select(item => item.ProductName)

//H) List all the discontinued products, specifying the product name and unit price.
Products
.Where (item => item.Discontinued)
.Select (item => new 
{
ProductName = item.ProductName,
UnitPrice = item.UnitPrice
})

//I) List the company names of all Suppliers in North America(Canada, USA, Mexico)
Suppliers
.Where 	(company => ((company.Address.Country == "Canada") || 
		(company.Address.Country == "USA") || 
		(company.Address.Country == "Mexico")))
.Select (company => company.CompanyName)



