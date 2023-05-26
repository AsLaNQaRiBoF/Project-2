using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication3.DAL;
using WebApplication3.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(opt =>
{
    
}).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(b => b.UseSqlServer(builder.Configuration["ConnectionStrings:Default"]));

var app = builder.Build();


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=DashBoard}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
