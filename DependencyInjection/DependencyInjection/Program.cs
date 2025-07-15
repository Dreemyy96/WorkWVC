using DependencyInjection.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddTransient<IRepository>(provider =>
//{
//	if (builder.Environment.IsDevelopment())
//	{
//		var x = provider.GetService<MemoryRepository>();
//		return x;
//	}
//	else
//	{
//		return new AlternateRepository();
//	}
//});
//builder.Services.AddTransient<MemoryRepository>();
//builder.Services.AddScoped<IRepository, MemoryRepository>();
builder.Services.AddSingleton<IRepository, MemoryRepository>();
builder.Services.AddTransient<IModelStorage, DictionaryStorage>();
builder.Services.AddTransient<ProductTotalizer>();

builder.Services.AddMvc(options=>options.EnableEndpointRouting = false);

var app = builder.Build();

app.UseStatusCodePages();
app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseMvcWithDefaultRoute();

app.Run();
