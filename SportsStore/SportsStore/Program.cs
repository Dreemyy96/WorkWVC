using SportsStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseDefaultServiceProvider(options => options.ValidateScopes = false);

builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration["Data:SportsStoreProducts:ConnectionString"]));

builder.Services.AddMvc(option=>option.EnableEndpointRouting = false);
builder.Services.AddTransient<IProductRepository, EFProductRepository>();

builder.Services.AddMemoryCache();
builder.Services.AddSession();

var app = builder.Build();
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();

app.UseMvc(routes => {
	routes.MapRoute(
		name: null,
		template: "{category}/Page{productPage:int}",
		defaults: new { controller = "Product", action = "List" }
		);
	routes.MapRoute(
		name: null,
		template: "Page{productPage:int}",
		defaults: new { controller = "Product", action = "List", productPage = 1 }
		);
	routes.MapRoute(
		name: null,
		template: "{category}",
		defaults: new { controller = "Product", action = "List", productPage = 1 }
		);
	routes.MapRoute(
		name: null,
		template: "",
		defaults: new { controller = "Product", action = "List", productPage = 1 }
		);
	routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
	
});
SeedData.EnsurePopulated(app);
app.Run();
