using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Views.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(options=>options.EnableEndpointRouting = false);

builder.Services.Configure<RazorViewEngineOptions>(options=> {
    options.ViewLocationExpanders.Add(new SimpleExpander());
    options.ViewLocationExpanders.Add(new ColorExpander());
    });
//builder.Services.Configure<MvcViewOptions>(options =>
//{
//	options.ViewEngines.Insert(0, new DebugDataViewEngine());
//});

var app = builder.Build();

app.UseStatusCodePages();
app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseMvcWithDefaultRoute();

app.Run();
