using Microsoft.EntityFrameworkCore;
using TutorialProjectPGSQL.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

string _GetConnStringName = builder.Configuration.GetConnectionString("connPostgreSQL");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(_GetConnStringName));


var app = builder.Build();
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
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
