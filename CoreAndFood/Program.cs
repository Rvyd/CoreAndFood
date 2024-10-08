using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(
	CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
	{
		x.LoginPath = "/Login/Index"; //e�er ki�i giri� yapmad�ysa buraya y�nlendirilecek

	});
builder.Services.AddMvc(config =>  //giri� i�lemini controller seviyesine ��kar�r
{
	var policy = new AuthorizationPolicyBuilder()
	.RequireAuthenticatedUser()
	.Build();
	config.Filters.Add(new AuthorizeFilter(policy));
});
var app = builder.Build();

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
	pattern: "{controller=ShowCase}/{action=Index}/{id?}");

app.Run();
