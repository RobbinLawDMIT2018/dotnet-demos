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

//A demonstration of using the navigational properties
//to access data on another table.

//Show all albums for U2, order by year, then by title decending
var q1 = 
Albums
.Where (x => x.Artist.Name.Equals ("U2"))
.OrderBy (x => x.ReleaseYear)
.ThenByDescending (x => x.Title)
.Select(x => x);

//to display the results of a query code in the Statement
//environment, you need to use .Dump()
//.Dump() is NOT C#
//.Dump() is a method within LinqPad
//.Dump() CAN NOT be used in your real code

//q1.Dump();
   
//List all jazz (genre) tracks ordered by Name
var q2 = 
Tracks
.Where (x => x.Genre.Name.Equals ("Jazz"))
.OrderBy (x => x.Name)
.Select(x => x);

//q2.Dump();