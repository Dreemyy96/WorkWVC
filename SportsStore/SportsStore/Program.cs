using SportsStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseDefaultServiceProvider(options => options.ValidateScopes = false);

builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration["Data:SportsStoreProducts:ConnectionString"]));
builder.Services.AddDbContext<AppIdentityDbContext>(option => option.UseSqlServer(builder.Configuration["Data:SportsStoreIdentity:ConnectionString"]));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
	.AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();

builder.Services.AddMvc(option=>option.EnableEndpointRouting = false);
builder.Services.AddTransient<IProductRepository, EFProductRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<Cart>(sp=>SessionCart.GetCart(sp));
builder.Services.AddTransient<IOrderRepository, EFOrderRepository>();


builder.Services.AddMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();
app.UseDeveloperExceptionPage();
app.UseSession();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseAuthentication();

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
IdentitySeedData.EnsurePopulated(app);
app.Run();
