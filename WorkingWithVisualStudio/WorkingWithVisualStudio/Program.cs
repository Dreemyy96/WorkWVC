var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(option=>option.EnableEndpointRouting = false);

var app = builder.Build();

app.UseStaticFiles();
app.UseMvcWithDefaultRoute();

app.Run();
