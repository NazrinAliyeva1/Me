

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProniaTask.DataAccesLayer;
using ProniaTask.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProniaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddIdentity<AppUser, IdentityRole>(opt=>
{
    opt.User.RequireUniqueEmail = true;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequiredLength = 4;
    opt.Password.RequireDigit = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
}
).AddEntityFrameworkStores<ProniaContext>()
.AddDefaultTokenProviders();

var app = builder.Build();

app.UseStaticFiles();
app.MapControllerRoute("areas", "{area:exists}/{controller=Slider}/{action=Index}/{id?}");
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
app.Run();