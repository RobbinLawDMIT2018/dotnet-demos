<Query Kind="Expression">
  <Connection>
    <ID>dd2dff55-ce65-4a8d-9b4d-17114eda0e3f</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>Chinook</Database>
  </Connection>
</Query>


//get all Artists
Artists
.Select (x => x)

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


//list all customers in alphabetic order by last name
//who live in the USA.
Customers
.OrderBy (x => x.LastName)
.Where (x => (x.Country.Equals ("USA") && x.State.Equals ("CA")))
.Select (x => x)