using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using webapp.Data;
using About;
using Security;
using Purchasing;
using Receiving;
using Sales;
using Servicing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

// Call the Backend Startup Extension to register services
builder.Services.AddAboutDependencies(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddSecurityDependencies(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddPurchasingDependencies(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddReceivingDependencies(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddSalesDependencies(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddServicingDependencies(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
