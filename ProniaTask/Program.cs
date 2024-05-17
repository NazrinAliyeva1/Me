using ProniaTask.DataAccesLayer;

var builder = WebApplication.CreateBuilder();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProniaContext>();
var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute("{default}", "{controller=Home}/{action=Index}/{id?}");
app.Run();