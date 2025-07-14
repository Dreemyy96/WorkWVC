using Microsoft.AspNetCore.Routing.Constraints;
using UrlsAndRoutes.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(options=>options.EnableEndpointRouting = false);

builder.Services.Configure<RouteOptions>(options =>
{
	options.LowercaseUrls = true;
	options.AppendTrailingSlash = true;
});

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
//app.UseMvc(routes =>
//{
//routes.MapRoute(name: "MyRoute", template: "{controller=Home}/{action=Index}/{id:alpha:minlength(6)?}"); /*constraints:new {id = new IntRouteConstraint()}*/
//	//{ *catchall} - для обработки любого количества сегментов
//	//:regex(^H.*), :regex(^Index$|^About$) - ограничение по шаблону
//	//routes.MapRoute(name: "ShopSchema2", template: "Shop/OldAction", defaults: new { controller = "Home", action = "Index" });
//	//routes.MapRoute(name: "ShopSchema", template: "Shop/{action}", defaults: new { controller = "Home" });
//	//routes.MapRoute("", template: "X{controller}/{action}");
//	//routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}"/*, defaults: new {action = "Index"}*/);
//	//routes.MapRoute(name: "", template: "Public/{controller}/{Action}");
//});
app.UseMvc(routes => {
	routes.MapRoute("areas", "{area:exists}/{controller=Home}/{action=Index}");
	//outes.Routes.Add(new LegacyRoute("articles/Windows_3.1_Overview.html", "/old/.NET_1.0_Class_Library"));

	//routes.MapRoute("NewRoute", "App/Do{action}", new { controller = "Home" });
	routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
	routes.MapRoute("out", "outbound/{controller=Home}/{action=Index}");

});

app.Run();
