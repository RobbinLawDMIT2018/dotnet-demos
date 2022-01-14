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

//create an alphabetic list of Albums by decades
//70s, 80s, 90s, modern. Show the Album title and the decade
//it was produced.
Albums
.Where (x => (x.ReleaseYear > 1969))
.OrderBy (x => x.Title)
.Select (x => new 
{
Title = x.Title,
Year = x.ReleaseYear,
Decade = ((x.ReleaseYear > 1969) && (x.ReleaseYear < 1980))
 ? "70s"
 : ((x.ReleaseYear > 1979) && (x.ReleaseYear < 1990))
 ? "80s"
 : ((x.ReleaseYear > 1989) && (x.ReleaseYear < 2000)) 
 ? "90s" 
 : "modern"
})
	
//List all tracks and indicate the play time in minutes and seconds, and storage to the nearest
//kilobytes (rounded up). Show track name, play time and storage.
Tracks
.Select (x => new 
{
Name = x.Name,
PlayTime = 	(x.Milliseconds).ToString() + "raw " +
				(x.Milliseconds / 60000).ToString() + "min " +
				(x.Milliseconds % 60000).ToString() + "remainder " +
				(x.Milliseconds % 60000 / 1000).ToString() + "sec",
Storage = x.Bytes / 1024 + 1
})
	
	
	
	
	
	
	
	
	
	