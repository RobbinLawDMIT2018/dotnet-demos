# Web Server (Back-End) Setup and Database Access via an About Page

> This is the **second** in a series of demos where we will be building a website to manage information about the **WestWind** traders.
>
> **This set is cumulative**; future demos in this series will build upon previous demos.

## Overview

We will create an additional class library project for the Entity, DLL, and BLL classes. We will also be creating a new page to test that the database configuration has been set up correctly.

### Install Database

A new database called [WestWind](./WestWind.dacpac) has been supplied to you for this demo. 

Use Microsoft SQL Management Studio to deploy the `WestWind.dacpac` file to the database. Remember to use the `Import Data-tier Application` option.

### Server (Back-End) Set Up

In this task, we will be creating an additional project for the "back-end" of the application and ensuring our solution follows rudimentary Client-Server architecture.

```csharp
# From the src/ folder
# Create a Class Library which will be the Back-End
dotnet new classlib -n webclasslib -o webclasslib
# Allow the webapp project to use the classlib project by referencing it.
dotnet add webapp/webapp.csproj reference webclasslib/webclasslib.csproj
# Add the project to the solution
dotnet sln "solution.sln" add webclasslib\webclasslib.csproj
```

To ensure that our web application works, build and run the project.

```csharp
# From the src/ folder
cd webapp
dotnet build
dotnet watch run
```

Alternately you could build and run from the *src/* folder. If you would like to test this out first make sure you are in the *src/* folder and then type `dotnet build "solution.sln"`. At this point, you could continue either with VS Code (type `dotnet watch run -p webapp\webapp.csproj` from the *src/* folder) or use VS 2022 by double-clicking the "solution.sln" in windows file explorer.

### Entity Framework

We will be using the **Microsoft.EntityFrameworkCore.SqlServer** NuGet package to connect to our database. Add this NuGet package to the class library project.

```csharp
# From the src/ folder
cd webclasslib
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

### Server Framework

Inside our class library `webclasslib` folder, we will create three folders: "Entities", "DAL", and "BLL". 

### Entities

In the "Entities" folder, we create a file called `BuildVersion.cs` and then create the appropriate class to model the database `BuildVersion` table in the ***WestWind*** database. We can use the following ERD to guide our coding, but we should always remember to confirm the model's structure with the actual tables in the database.

![ERD](../WestWindERD.png)

We will make the namespace as follows:  `namespace Entities`.

For the `BuildVersion` entity, we will override the `.ToString()` method to display the version information as a string. We will use appropriate formatting - one that would be suitable for either web or console applications.


We will add the following code to the `BuildVersion.cs` file:

```csharp
using System; //need for DateTime
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities 
{
    [Table("BuildVersion")]
    public class BuildVersion
    {
        [Key]
        public int Id { get; set; }
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Build { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ReleaseDate { get; set; }

        public override string ToString() 
        {
		    return $"Id: {Id}, Major: {Major}, Minor: {Minor}, Build: {Build}, Release Date: {ReleaseDate}";
	    }
    }
}
```

### DAL Context

In the "DAL" folder, we will create a file called `Context.cs` which will contain the `Context` class and ensure it inherits from `DbContext`:

We will add the following code to the `Context.cs` file:

```csharp
using Microsoft.EntityFrameworkCore;
using Entities;

namespace DAL 
{
    public class Context : DbContext 
    {
        public Context(DbContextOptions<Context> options)
            : base(options) {}
    
        public DbSet<BuildVersion> BuildVersion { get; set; }
    }
}
```
### BLL Services

In the "BLL" folder of our class library we will add the file `DbVersionServices.cs` that will hold the class `DbVersionServices`. This class must have a constructor that requires an instance of the `Context` class.

In this class, we will create a public method called `GetDbVersion()` that has no parameters and returns an instance of the `DbVersion` entity. The related database table should only have one row, so you can return that first item from the database context.

We will add the following code to the `DbVersionServices.cs` file:

```csharp
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Entities;
using DAL;

namespace BLL 
{
    public class DbVersionServices 
    {
        private readonly Context Context;
        public DbVersionServices(Context context) 
        {
            if (context == null)
                throw new ArgumentNullException();
            Context = context;
        }

        public DbVersion GetDbVersion() 
        {
            Console.WriteLine($"DbServices: GetDbVersion;");
            var result = Context.BuildVersion.ToList();
            return result.First();
        }
```
### Register Context and Services

We must configure the following services in our webapp.

- `Context` class as a DbContext using SQL Server
- `DbVersionServices` class as a transient service

#### DOTNET 5
In the `startup.cs` file include the following:
```csharp
//using statements added
using Microsoft.EntityFrameworkCore;
using DAL;
using BLL;

namespace webapp

public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();

        // Context class as a DbContext using SQL Server
        services.AddDbContext<Context>(context => 
            context.UseSqlServer(Configuration.GetConnectionString("WWDB")));
        
        //TrainWatchServices class as a transient service
        services.AddTransient<DbVersionServices>();
    }
```
#### DOTNET 6
In the `Program.cs` file include the following:
```csharp
//using statements added
using Microsoft.EntityFrameworkCore;
using DAL;
using BLL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Get the connection string.
var connectionString = builder.Configuration.GetConnectionString("WWDB");

// TrainWatchContext class as a DbContext using SQL Server
builder.Services.AddDbContext<Context>(context => 
    context.UseSqlServer(connectionString));

// TrainWatchServices class as a transient service
builder.Services.AddTransient<DbVersionServices>();

var app = builder.Build();
```
NOTE: The new code must be between the `builder.Services.AddRazorPages();` and `var app = builder.Build();`

### Setup Connection String In `appsettings.json`

In addition, you will need to set up the database connection string in the `appsettings.json` file:

```csharp
"ConnectionStrings": {
    "WWDB" : "Server=.;Database=WestWind;Integrated Security=true;"
  },
```
### Create The `About` Page

Create an `About.cshtml`/`About.cshtml.cs` Razor Page to display the database version information. The Page Model class must declare in its constructor a dependency on the `DbVersionServices` class. 

```csharp
# From the src/ folder
cd webapp
dotnet new page -n About -o Pages
```

We need to add a menu item so that this page can be navigated to using the main menu; we will use the text "About" for the link.

On the `About` page, we will display the database version information from the DbVersion table of the database.

We will add the following code to the `About.cshtml` file:

```csharp
@page
@model MyApp.Namespace.AboutModel
@{
}
<h5>About The Database Used for This Site</h5>

@if(!string.IsNullOrEmpty(Model.ErrorMessage))
{
    <p style="color:red; font-weight: bold;">@Model.ErrorMessage</p>
}

@if(!string.IsNullOrEmpty(Model.SuccessMessage))
{
    <p style="color:green; font-weight: bold;">@Model.SuccessMessage</p>
}

<table class="table table-hover">
    <tr>
        <th>Database's Version</th>
    </tr>
    <tr>
        <td>@Model.DatabaseVersion</td>
    </tr>
</table>
```

We will add the following code to the `About.cshtml.cs` file:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// Additional Namespaces
using Entities;
using BLL;

namespace MyApp.Namespace
{
    public class AboutModel : PageModel
    {
        private readonly DbVersionServices Services;
        public AboutModel(DbVersionServices services) {
           Services = services;
        }

        public BuildVersion? DatabaseVersion { get; set; }

        public string? SuccessMessage {get; set;}
        public string? ErrorMessage {get; set;}

        public void OnGet()
        {
            try
            {
                Console.WriteLine($"AboutModel: OnGet");
                DatabaseVersion = Services.GetDbVersion();
                SuccessMessage = $"Database Retrieve Successful";
            }
            catch (Exception ex)
            {
                GetInnerException(ex);
            }
            
        }

        public void GetInnerException(Exception ex)
        {
            Exception rootCause = ex;
            while (rootCause.InnerException != null)
                rootCause = rootCause.InnerException;
            ErrorMessage = rootCause.Message;
        }
    }
}
```

To ensure that our web application works, build and run the webapp project.

```csharp
# From the src/ folder
cd webapp
dotnet build
dotnet watch run
```