using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Online_store.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Online_storeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Online_storeContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=ItemModels}/{action=Index}");

app.Run();
