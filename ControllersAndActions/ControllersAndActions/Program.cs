var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(options=>options.EnableEndpointRouting = false);
builder.Services.AddMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

app.UseStatusCodePages();
app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseSession();
app.UseMvcWithDefaultRoute();

app.Run();
