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

// List the full name of all the employees who look after 7 or more territories
from person in Employees
where person.EmployeeTerritories.Count >= 7
select person.FirstName + " " + person.LastName

Employees
.Where (person => (person.EmployeeTerritories.Count >= 7))
.Select (person => ((person.FirstName + " ") + person.LastName))