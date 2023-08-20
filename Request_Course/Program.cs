using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Request_Course.Data;
using Request_Course.Serivces;
using Request_Course.Serivces.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ReqContexts>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Requrseing"));
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                  .AddCookie(option =>
                  {
                      option.LoginPath = "/Admin/Login";
                      option.LogoutPath = "/Admin/Logout";
                      option.ExpireTimeSpan = TimeSpan.FromDays(30);
                  });
builder.Services.AddScoped<IRepository, Repository>();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=GetPhone}/{id?}");

app.Run();
