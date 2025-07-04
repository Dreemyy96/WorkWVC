var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(option => option.EnableEndpointRouting = false);

var app = builder.Build();

app.UseDeveloperExceptionPage();

//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Hellow world!");
//});

app.UseMvcWithDefaultRoute();

app.Run();
