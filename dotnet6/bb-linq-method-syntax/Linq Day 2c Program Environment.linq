<Query Kind="Program">
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

void Main()
{
	
	//If you are use the C# program environment you will place
	//your query results into a local variable.
	//You will then display your contents of the local variable
	//using the .Dump() Linqpad extension method.
	//One does NOT need to highlight the query to execute if
	//there are multiple queries within the phyiscal file.
	//Queries will execute from top to bottom in the file.
	
	//In the program environment you CAN define classes and methods.
	
	//execute a method
	var results = BLLQuery("Aerosmith");
	results.Dump();
}

//Define other methods, classes and namespaces here
//This class would be from the ViewModel.
public class SongItem
{
	public string Song{get;set;}
	public string AlbumTitle{get;set;}
	public int Year{get;set;}
	public int Length{get;set;}
	public decimal Price{get;set;}
	public string Genre{get;set;}
	public string ArtistName{get;set;}
}

//Create a method to simulate the BLL method in a controller.
public List<SongItem> BLLQuery(string artistname)
{
	//change the Anonymous datatype to a strongly-typed datatype
	var results = 
	Tracks
	.Where (x => x.Album.Artist.Name.Equals (artistname))
	.OrderBy (x => x.Name)
	.Select (x => new SongItem
	     {
	        Song = x.Name, 
	        AlbumTitle = x.Album.Title, 
	        Year = x.Album.ReleaseYear, 
	        Length = x.Milliseconds, 
	        Price = x.UnitPrice, 
	        Genre = x.Genre.Name, 
	        ArtistName = x.Album.Artist.Name
	     }
	);
	return results.ToList();
}
