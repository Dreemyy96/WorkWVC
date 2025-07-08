using SportsStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseDefaultServiceProvider(options => options.ValidateScopes = false);

builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration["Data:SportsStoreProducts:ConnectionString"]));

builder.Services.AddMvc(option=>option.EnableEndpointRouting = false);
builder.Services.AddTransient<IProductRepository, EFProductRepository>();
var app = builder.Build();
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();

app.UseMvc(routes => {
	routes.MapRoute(
		name: "pagination",
		template: "Products/Page{productPage}",
		defaults: new { Controller = "Product", action = "List" }
		);
	routes.MapRoute(
		name: "default",
		template: "{controller=Product}/{action=List}/{id?}");
});
SeedData.EnsurePopulated(app);
app.Run();
