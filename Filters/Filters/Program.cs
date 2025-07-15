using Filters.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(options=>options.EnableEndpointRouting = false);
builder.Services.AddScoped<IFilterDiagnostics, DefaultFilterDiagnostics>();

var app = builder.Build();

app.UseStatusCodePages();
app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseMvcWithDefaultRoute();

app.Run();
