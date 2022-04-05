using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Online_store.Data;
using Online_store.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Online_storeContext>(optionsI =>
    optionsI.UseSqlServer(builder.Configuration.GetConnectionString("Online_storeContext")));
builder.Services.AddDbContext<UserContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("Online_storeContext")));

builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<UserModel, IdentityRole>()
	.AddEntityFrameworkStores<UserContext>()
	.AddDefaultTokenProviders();


var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=ItemModels}/{action=Index}");

app.Run();
