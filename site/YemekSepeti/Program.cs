using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using YemekSepeti.Controllers.EntityFramework;
using YemekSepeti.DataAccess.EntityFramework;
using YemekSepetiProje.Entities;
using YemekSepetiProje.Entitys;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Program>());
builder.Services.AddSession();
//aaaaa





//aaaaa
var app = builder.Build();

//11
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseSession();
app.Run();
