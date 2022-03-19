<!-- https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new-sdk-templates#web-options -->

# Web Client (Front-End) Setup and Form Input via a Contact Page

> This is the **first** in a series of demos where we will be building a website to manage information about the **WestWind** traders.
>
> **This set is cumulative**; future demos in this series will build upon previous demos.

## Overview

We will create a new ASP.NET Core Web Application (Razor Pages).

```csharp
# From the src/ folder
# Create a Razor Pages Web Application which will be the Front-End
# Without Authentication
dotnet new webapp -n webapp -o webapp -au None
# Or with Authentication
dotnet new webapp -n webapp -o webapp -au Individual
#Create a solution to use with Visual Studio 2022
dotnet new sln -n solution
# Add the project to the solution
dotnet sln "solution.sln" add ./webapp/webapp.csproj
```

To ensure that your web application works, build and run your project.

```csharp
# From the src/ folder
cd webapp
dotnet build
dotnet watch run
```

A browser window should open (https://localhost:5001). If you get a certificate error, you need to create a self-signed certificate for your developer machine by typing the following (read more on this [Microsoft Docs page](https://docs.microsoft.com/aspnet/core/security/enforcing-ssl#trust-the-aspnet-core-https-development-certificate-on-windows-and-macos)).

```csharp
dotnet dev-certs https --trust
```
Alternately you could build and run from the *src/* folder. If you would like to test this out first make sure you are in the *src/* folder and then type `dotnet build "solution.sln"`. At this point, you could continue either with VS Code (type `dotnet watch run -p webapp\webapp.csproj` from the *src/* folder) or use VS 2022 by double-clicking the "solution.sln" in windows file explorer.

### Modify `Index.cshtml`

We will modify the home page to include the following.

- The title of the site (**WestWind Traders**)
- A simple logo for the site. Create an `images` folder in `wwwroot` and store an image there. Get a random image from the web as a jpg or png.
- One paragraph welcome and summary description of the site.

### Update the `_Layout.cshtml`

Ensure that the menu navigation has the following items.

- A link to the home page (`/Index`) with the text "Home"
- A link to the contact page (`/Contact`) with the text "Contact"
- A link to the privacy page (`/Privacy`) with the text "Privacy"

### Add `Contact` Page

Create an `Contact.cshtml`/`Contact.cshtml.cs` Razor Page.

```csharp
# From the src/ folder
cd webapp
dotnet new page -n Contact -o Pages
```
To ensure that your web application works, build and run your project.

```csharp
# From the src/ folder
cd webapp
dotnet build
dotnet watch run
```

In Contact.cshtml we will add a "Contact" page with a form (`method="POST"`) to allow the user to send information to the server. The form will include many form elements that may be used in future web apps.

In the Contact.cshtml.cs file we will add C# code in the methods OnGet(), and OnPost(), to process the form's input by echoing back all of the data entered by the user in a "SuccessMessage".