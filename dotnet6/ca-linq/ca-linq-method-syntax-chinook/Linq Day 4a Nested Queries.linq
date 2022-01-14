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

//Nested queries
//simply put are queries with queries

//list all "sales support" employees showing their fullname (lastname, firstname),
//their title and the number of customers each support. Order by fullname.
//In addition show a list of the customers for each employee. Show the customer
//fullname, city and state

Employees
.Select (x => x)

Employees
.Where (x => (x.Title.Contains ("Support") && x.Title.Contains ("Sales")))
.OrderBy (x => x.LastName)
.ThenBy (x => x.FirstName)
.Select (x => new 
{
name = ((x.LastName + ", ") + x.FirstName),
title = x.Title,
clientcount1 = x.SupportRepCustomers.Count(),
clientcount2 = x.SupportRepCustomers.Select(y => y).Count(),
clientlist1 = 	x.SupportRepCustomers
				.OrderBy(y => y.LastName)
				.ThenBy(y => y.FirstName)
				.Select (y => new 
				{
				name = ((y.LastName + ", ") + y.FirstName),
				city = y.City,
				state = y.State
				}),
clientlist2 = 	Customers
				.Where (y => (y.SupportRepId == (Int32?)(x.EmployeeId)))
				.OrderBy (y => y.LastName)
				.ThenBy (y => y.FirstName)
				.Select (y => new 
				{
				name = ((y.LastName + ", ") + y.FirstName),
				city = y.City,
				state = y.State
				})
})


//Create a list of albums showing their title and artist.
//Show albums with 25 or more tracks only.
//Show the songs on the album (name and length)

//in the inner query create an IEnumberable collection
Albums
.Where (x => (x.Tracks.Count () >= 25))
.Select (x => new 
{
title = x.Title,
artist = x.Artist.Name,
songcount = x.Tracks.Count (),
songs = x.Tracks
		.Select (y => new 
		{
		name = y.Name,
		length = y.Milliseconds
		})
})


//Create a Playlist report that shows the Playlist name, the number
//of songs on the playlist the user name belonging to the playlist
//and the songs on the playlist with their Genre

Playlists
.Where (x => (x.PlaylistTracks.Count () >= 20))
.Select (x => x)

Playlists
.Where (x => (x.PlaylistTracks.Count() >= 20))
.Select (x => new 
{
name = x.Name,
Trackcount = x.PlaylistTracks.Count(),
user = x.UserName,
songs = x.PlaylistTracks
		.Select (y => new 
		{
		track = y.Track.Name,
		genre = y.Track.Genre.Name
		})
})

