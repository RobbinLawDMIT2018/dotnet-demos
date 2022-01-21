<Query Kind="Statements">
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

//Grouping

//Basically, grouping is the technique of placing a large
//pile of data into smaller piles of data depending on
//a criteria.

//Navigational properties allow for natural grouping of
//parent to child (pkey/fkey) collections
//parentinstance.childnavproperty.Count() counts all the
//child records associated with the parent instance.

//Problem: what if there is no navigational property for
//         the grouping of the data collection?

//Here you can use the group clause to create a set of
//smaller collections based on the desired criteria.

//It is important to remember that once the smaller groups
//are created, ALL reporting MUST use the smaller groups
//as the collection reference.

//Grouping is NOT the same as Ordering.

//Syntax
//  "group" instance "by" criteria "into" group reference name

//The instance is one record from the original pile of data.
//The criteria can be:
//    a) a single attribute ....
//    b) multiple attributes new{....,....,....}
//    c) a class classname

//If you wish to do processing on the smaller group
//you will place the grouping results into a smaller
//pile of data referenced by a specified name.

//Groups have 2 components
//  a) key component
//  b) the data component

//EXAMPLE 1:
//Report albums by ReleaseYear showing the year and
//the number of albums for the year. Order by the
//most albums, then by the year within count.

//STEP 1: is to get a feel for the data in the table.
	
var results1a =
Albums
.OrderBy (x => x.Title)
.Select (x => x);

//results1a.Dump();


//STEP 2: Create and display the grouping.

//var results1b = 	from x in Albums
//					group x by x.ReleaseYear into gYear
//					select gYear;

var results1b =
Albums
.GroupBy (x => x.ReleaseYear)
.Select (gYear => gYear);

//results1b.Dump();

//STEP 3: Create the reporting row for the group.
					
var results1c =
Albums
.GroupBy (x => x.ReleaseYear)
.Select (gYear => new 
{
year = gYear.Key,
albumcount = gYear.Count ()
});

//results1c.Dump();

//STEP 4: Complete any additional report customization like ordering.
	
var results1d =
Albums
.GroupBy (x => x.ReleaseYear)
.OrderByDescending (gYear => gYear.Count ())
.ThenBy (gYear => gYear.Key)
.Select (gYear => new 
{
year = gYear.Key,
albumcount = gYear.Count ()
});

//results1d.Dump();


//EXAMPLE 2:
//Report albums by ReleaseYear showing the year and
//the number of albums for the year. 
//Order by the most albums, then by the year within count.
//Report the album title, artist name and number of
//album tracks. Report ONLY albums of the 90s.

//the process of filtering for the 90s can be done
// a) on the original pile of data, OR
// b) on the grouped piles of data

var results2a =
Albums
.Where (x => ((x.ReleaseYear > 1989) && (x.ReleaseYear < 2000)))
.GroupBy (x => x.ReleaseYear)
.OrderByDescending (gYear => gYear.Count ())
.ThenBy (gYear => gYear.Key)
.Select (gYear => gYear);

//results2a.Dump();

//Does not work with Chinook (trackcount is always the album count).
//but does work with ChinookEntity.
var results2b =
Albums
.Where (x => ((x.ReleaseYear > 1989) && (x.ReleaseYear < 2000)))
.GroupBy (x => x.ReleaseYear)
.OrderByDescending (gYear => gYear.Count())
.ThenBy (gYear => gYear.Key)
.Select (gYear => new 
{
year = gYear.Key,
albumcount = gYear.Count(),
albumdata = gYear
			.Select (y => new 
			{
			albumtitle = y.Title,
			artist = y.Artist.Name,
			trackcount3 = y.Tracks.Count()
			})
});

//results2b.Dump();

//EXAMPLE 3:
//list the number of tracks by Genre name. 
//Count tracks for the Name.


//This does not work with ChinookEntity it crashes.
//but it does work with Chinook.
var results3a = 
Tracks
//.AsEnumerable()
//.GroupBy(track => track.GenreId)
.GroupBy (trk => trk.Genre.Name)
.OrderBy (gTemp => gTemp.Key)
.Select (gYear => gYear);

//results3a.Dump();

//same report but using the entity as the group criteria

//When you group on an entity, the entire entity instance becomes
//the content of your key value.
//To reference a particular attribute of the key entity value
//use normal object referencing (dot operator).


var results3b =
Tracks
.GroupBy (trk => trk.Genre)
.OrderBy (gTemp => gTemp.Key.Name)
.Select (gYear => gYear);

//results3b.Dump();


var results3c =
Tracks
.GroupBy (trk => trk.Genre)
.OrderBy (gTemp => gTemp.Key.Name)
.Select (gTemp => new 
{
genre = gTemp.Key.Name,
numberof = gTemp.Count ()
});

//results3c.Dump();


//EXAMPLE 4:
//Grouping by multiple attributes.

//var results4a = 	from track in Tracks
//					group track by new {track.Genre.Name, track.AlbumId} into gresult
//					select gresult;

var results4a =
Tracks
.GroupBy (track => new 
{
Name = track.Genre.Name,
AlbumId = track.AlbumId
})
.Select (gresult => gresult);

//results4a.Dump();


//var results4b = 	from track in Tracks
//					group track by new {track.Genre.Name, track.AlbumId} into gresult
//					select new
//					{
//							id = gresult.Key.Name,
//							numofsongs = gresult.Count()
//					};

var results4b =
Tracks
.GroupBy (track => new 
{
Name = track.Genre.Name,
AlbumId = track.AlbumId
})
.Select (gresult => new 
{
id = gresult.Key.Name,
numofsongs = gresult.Count ()
});

//results4b.Dump();
