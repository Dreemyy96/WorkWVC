using Cities.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IRepository, MemoryRepository>();

var app = builder.Build();

app.UseStatusCodePages();
app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();
