using ApiControllers.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(options=>options.EnableEndpointRouting = false);
builder.Services.AddSingleton<IRepository, MemoryRepository>();

var app = builder.Build();

app.UseStatusCodePages();
app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseMvcWithDefaultRoute();


app.Run();
