using Filters.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(options=> {
    options.EnableEndpointRouting = false;
    options.Filters.Add(new MessageAttribute("this is globaly scoped filter"));
});
//builder.Services.AddSingleton<IFilterDiagnostics, DefaultFilterDiagnostics>();
//builder.Services.AddSingleton<TimeFilter>();

builder.Services.AddScoped<IFilterDiagnostics, DefaultFilterDiagnostics>();
builder.Services.AddScoped<TimeFilter>();
builder.Services.AddScoped<ViewResultDiagnostics>();
builder.Services.AddScoped<DiagnosticsFilter>();
//builder.Services.AddMvc(options => { options.Filters.AddService(typeof(ViewResultDiagnostics));
//options.Filters.AddService(typeof(DiagnosticsFilter));
//});




var app = builder.Build();

app.UseStatusCodePages();
app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseMvcWithDefaultRoute();

app.Run();
