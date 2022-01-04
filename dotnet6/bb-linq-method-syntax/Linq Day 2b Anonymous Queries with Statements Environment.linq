<Query Kind="Statements">
  <Connection>
    <ID>dd2dff55-ce65-4a8d-9b4d-17114eda0e3f</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>Chinook</Database>
  </Connection>
</Query>


//to set lines as comments CRTL (HOLD) K, C
//to uncomment CRTL (Hold) K, U

//Anonymous Types

//this is used when you are not selecting the entire table and relationships.

//normally used when you have
//a) subset of table
//b) records from multiple tables

//List all customers in alphabetic order by last name,
//firstname who live in the USA with a yahoo email.
//Show only, the customer id, lastname, firstname (as one), and
//the city and state in which they reside.				
var q1 =
Customers
.Where (x => (x.Country.Equals ("USA") && x.Email.Contains ("yahoo")))
.OrderBy (x => x.LastName)
.ThenBy (x => x.FirstName)
.Select (x => new  
	{
	ID = x.CustomerId, 
	Name = ((x.LastName + ", ") + x.FirstName), 
	City = x.City, 
	State = x.State, 
	Country = x.Country, 
	Email = x.Email
	}
);
	
//to display the results of a query code in the Statement
//environment, you need to use .Dump()
//.Dump() is NOT C#
//.Dump() is a method within LinqPad
//.Dump() CAN NOT be used in your real code

//q1.Dump();

//Example of a Ternary Expression.
//List all the albums released in 1990, ordered by Title. Show
//the Album title, the Artist Name, and the Release Label. If
//there is no Label display "UnKnown".
var q2 =
Albums
.Where (x => (x.ReleaseYear == 1992))
.OrderBy (x => x.Title)
.Select (x => new  
     {
        AlbumTitle = x.Title, 
        ArtistName = x.Artist.Name, 
        AlbumLabel = (x.ReleaseLabel == null) ? "Unknown" : x.ReleaseLabel
     }
);

//q2.Dump();














