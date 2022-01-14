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

//Aggregrates
//.Count() method or .Count property, same result, does not need a delegate expression
//.Sum(), .Max(), .Min(), .Average(), require a delegate expression so all are methods

//aggregrates work ONLY on a collection of data NOT on a single row
//a collection CAN have 0, 1 or more rows
Albums
.Where (x => (x.Tracks.Count() > 25))
.Select (x => new 
{
AlbumTitle = x.Title,
//AvgLength = x.Average(y => y.Milliseconds) //wrong a single row not a collection
AveTrackLength = x.Tracks.Average(y => y.Milliseconds),
NumOfTracks = x.Tracks.Count
})



//List all Albums showing, the Title, Artist Name and number of tracks
//on that album

//x (is the current Album instance/record).Tracks(navigational property).aggregrate
//because Tracks is a collection of the Album instance (ICollection<T>)
//    we can used the aggregrate on the expression
//HOWEVER
//we can NOT go x.Artist.aggregrate BECAUSE Artist is NOT a collection
Albums
.Where (x => (x.Tracks.Count > 0))
.OrderBy (x => x.Tracks.Count)
.Select (x => new 
{
AlbumTitle = x.Title,
ArtistName = x.Artist.Name,
NumOfTracks = x.Tracks.Count,
AvgTrackLength = x.Tracks.Average(y => y.Milliseconds),
MaxTrackLength = x.Tracks.Max(y => y.Milliseconds),
MinTrackLength = x.Tracks.Min(y => y.Milliseconds),
AlbumPrice = x.Tracks.Sum(y => y.UnitPrice)
})





