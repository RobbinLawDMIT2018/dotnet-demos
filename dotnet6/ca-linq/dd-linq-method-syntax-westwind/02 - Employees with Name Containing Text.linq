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
from person in Employees
where person.FirstName.Contains("an")
select person
