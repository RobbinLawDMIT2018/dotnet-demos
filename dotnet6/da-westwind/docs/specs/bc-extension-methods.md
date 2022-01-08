# Web Server (Back-End) Extension Methods

> This is the **third** in a series of demos where we will be building a website to manage information about the **WestWind** traders.
>
> **This set is cumulative**; future demos in this series will build upon previous demos.

## Overview

We will modify our existing app to allow us to take advantage of `extension methods` in C#.

### Register Context and Services but using extension methods in the Back-End

We must configure the following services in our webapp.

- `Context` class as a DbContext using SQL Server
- `DbVersionServices` class as a transient service

#### DOTNET 6
In the Program.cs file modify the code as follows:
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

// Call the Backend Extension Method to register services
builder.Services.AddBackendDependencies(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();
```
NOTE: The new code must be between the `builder.Services.AddRazorPages();` and `var app = builder.Build();`

### Extension Methods File

Inside our class library `webclasslib` folder, we will create a new file that is called `BackendExtensions.cs` which will contain the `BackendExtensions` class:
.

We will add the following code to the file `BackendExtensions.cs`:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Additional Namespaces
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DAL;
using BLL;

namespace webclasslib
{
    public static class BackendExtensions
    {
        public static void AddBackendDependencies(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<Context>(options);

            services.AddTransient<DbVersionServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetRequiredService<Context>();
                return new DbVersionServices(context);
            });

        }
    }
}
```

To ensure that our web application works, build and run the project.

```csharp
# From the src/ folder
cd webapp
dotnet build
dotnet watch run
```