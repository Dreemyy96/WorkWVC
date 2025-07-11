using ConfiguringApps.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(options=>options.EnableEndpointRouting = false);
builder.Services.AddSingleton<UptimeService>();

var app = builder.Build();

//app.UseMvcWithDefaultRoute();

app.UseMiddleware<ErrorMiddleware>();
app.UseMiddleware<BrowserTypeMiddleware>();
app.UseMiddleware<ShortCircuitMiddleware>();
app.UseMiddleware<ContentMiddleware>();

app.MapGet("/", () => "Hello World!");

app.Run();
