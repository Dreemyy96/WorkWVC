var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(options=>options.EnableEndpointRouting = false);

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseMvc(routes =>
{
	routes.MapRoute("", template:"X{controller}/{action}")
	routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}"/*, defaults: new {action = "Index"}*/);
	routes.MapRoute(name: "", template: "Public/{controller}/{Action}");
});

app.Run();
