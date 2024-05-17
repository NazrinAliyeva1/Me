

using Microsoft.EntityFrameworkCore;
using ProniaTask.DataAccesLayer;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProniaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));


var app = builder.Build();

app.UseStaticFiles();
app.MapControllerRoute("areas", "{area:exists}/{controller=Slider}/{action=Index}/{id?}");
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
app.Run();