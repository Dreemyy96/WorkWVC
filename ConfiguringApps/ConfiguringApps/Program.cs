using ConfiguringApps.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddMvc(options=>options.EnableEndpointRouting = false).AddMvcOptions(options=>options.RespectBrowserAcceptHeader = true);
builder.Services.AddSingleton<UptimeService>();

var app = builder.Build();

//app.UseMvcWithDefaultRoute();

if (app.Configuration.GetSection("ShortCircuitMiddleware").GetValue<bool>("EnableBrowserShortCircuit"))
{
	app.UseMiddleware<BrowserTypeMiddleware>();
	app.UseMiddleware<ShortCircuitMiddleware>();
}

if (app.Environment.IsDevelopment())
{
	//app.UseMiddleware<ErrorMiddleware>();
	//app.UseMiddleware<BrowserTypeMiddleware>();
	//app.UseMiddleware<ShortCircuitMiddleware>();
	//app.UseMiddleware<ContentMiddleware>();

	//генерация подробной страницы ошибки
	app.UseDeveloperExceptionPage();
	app.UseStatusCodePages();
}
else
{
	//указывает какой представление должно отобразиться при ошибке
	app.UseExceptionHandler("/Home/Error");
}
//позволяет использовать статичские файлы
app.UseStaticFiles();
//настраивает стандартную маршрутизацию
app.UseMvc(routes =>
{
	routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
});

//app.MapGet("/", () => "Hello World!");

app.Run();
