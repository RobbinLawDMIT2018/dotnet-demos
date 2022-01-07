<Query Kind="Expression">
  <Connection>
    <ID>c35fe573-e6f1-4520-a46f-f69153e5ca99</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <Server>.</Server>
    <Database>Chinook</Database>
    <DisplayName>ChinookEntity</DisplayName>
    <DriverData>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
</Query>


//get all Artists
Artists
.Select (x => x.Name)

//ordering
Artists
.OrderBy (x => x.Name)
.Select (x => x)


//targeting exact values
Artists
.Where (x => x.Name.Equals ("AC/DC"))
.Select (x => x)

//filtering data
Artists
.Where (x => x.Name.Contains ("Q"))
.Select (x => x)


//sorting a filter set of data
Artists
.Where (x => x.Name.Contains ("Q"))
.OrderBy (x => x.Name)
.Select (x => x)

//show all Albums released in 
//the 90's (1990-1999), but ordered first by ReleaseYear descending, and 
//then by Title ascending.
Albums
.Where (x => ((x.ReleaseYear >= 1990) && (x.ReleaseYear <= 1999)))
.OrderByDescending (x => x.ReleaseYear)
.ThenBy (x => x.Title)
.Select (x => x)

Albums
.Where (x => x.ReleaseYear >= 1990)
.Where (x => x.ReleaseYear <= 1999)
.OrderByDescending (x => x.ReleaseYear)
.ThenByDescending (x => x.Title)
.Select (x => x)

//list all customers in alphabetic order by last name
//who live in California (CA) in the USA.
Customers
.Select (x => x)

Customers
.OrderBy (x => x.LastName)
.Where (x => (x.Country.Equals ("USA") && x.State.Equals ("CA")))
.Select (x => x)