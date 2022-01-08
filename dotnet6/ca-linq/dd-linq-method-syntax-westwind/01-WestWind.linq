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

// - Filter on partial name
// List employees who have an "an" in their first name
Employees
.Where (person => person.FirstName.Contains ("an"))

// List the full name of all the employees who look after 7 or more territories
Employees
.Where (person => (person.EmployeeTerritories.Count >= 7))
.Select (person => ((person.FirstName + " ") + person.LastName))

// List the first and last name of all the employees who look after 7 or more territories
// as well as the names of all the territories they are responsible for
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

// List all the employees who do not manage anyone.
Employees
.Where (person => (person.ReportsToChildren.Count == 0))
.Select (person => new 
{
Name = ((person.FirstName + " ") + person.LastName),
JobTitle = person.JobTitle
})

// List all the employees who are managers and their subordinates.
Employees
.Where (person => (person.ReportsToChildren.Count > 0))
.Select (person => new 
{
Name = ((person.FirstName + " ") + person.LastName),
JobTitle = person.JobTitle,
Subordinates = 	person
				.ReportsToChildren
				.Select (emp => new 
				{
				GivenName = emp.FirstName,
				Surname = emp.LastName
				})
})
