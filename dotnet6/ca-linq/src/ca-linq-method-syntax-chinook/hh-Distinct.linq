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

//.Distinct() removes duplicates but sometimes reorders.

//Create a list of customer countries

var q1a =
Customers
.OrderBy(x => x.Country)
.Select(x => x.Country);

//q1a.Dump();

//Here we can put the Distinct last as we are sorting
//and selecting on the same thing, Country.
var q1b =
Customers
.OrderBy(x => x.Country)
.Select(x => x.Country)
.Distinct();

//q1b.Dump();

//obtain a distinct list of all playlist tracks for Roberto Almeida (user AlmeidaR)

var q2a =
PlaylistTracks
.Where(x => x.Playlist.UserName.Contains("Almeida"))
.OrderBy(x => x.Track.Name)
.Select(x => x);

//q2a.Dump();

var q2b =
PlaylistTracks
.Where(x => x.Playlist.UserName.Contains("Almeida"))
.OrderBy(x => x.Track.Name)
.Select(x => new
{
UserName = x.Playlist.UserName,
song = x.Track.Name,
genre = x.Track.Genre.Name,
id = x.TrackId
});

//q2b.Dump();

//Here we must reorder after the Distinct
//as the Distinct reorders by id.
var q2c =
PlaylistTracks
.Where(x => x.Playlist.UserName.Contains("Almeida"))
.OrderBy(x => x.Track.Name)
.Select(x => new
{
	UserName = x.Playlist.UserName,
	song = x.Track.Name,
	genre = x.Track.Genre.Name,
	id = x.TrackId
}).Distinct()
.OrderBy(x => x.song);

//q2c.Dump();