using UsingViewComponents.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IProductRepository, MemoryProductRepository>();
builder.Services.AddSingleton<ICityRepository, MemoryCityRepository>();
builder.Services.AddControllersWithViews();


var app = builder.Build();

app.UseStatusCodePages();
app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
