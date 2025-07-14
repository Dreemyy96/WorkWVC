using Microsoft.AspNetCore.Routing.Constraints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(options=>options.EnableEndpointRouting = false);

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
//app.UseMvc(routes =>
//{
//routes.MapRoute(name: "MyRoute", template: "{controller=Home}/{action=Index}/{id:alpha:minlength(6)?}"); /*constraints:new {id = new IntRouteConstraint()}*/
//	//{ *catchall} - ��� ��������� ������ ���������� ���������
//	//:regex(^H.*), :regex(^Index$|^About$) - ����������� �� �������
//	//routes.MapRoute(name: "ShopSchema2", template: "Shop/OldAction", defaults: new { controller = "Home", action = "Index" });
//	//routes.MapRoute(name: "ShopSchema", template: "Shop/{action}", defaults: new { controller = "Home" });
//	//routes.MapRoute("", template: "X{controller}/{action}");
//	//routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}"/*, defaults: new {action = "Index"}*/);
//	//routes.MapRoute(name: "", template: "Public/{controller}/{Action}");
//});
app.UseMvcWithDefaultRoute();

app.Run();
