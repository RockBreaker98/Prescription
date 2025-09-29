using Microsoft.EntityFrameworkCore;
using PrescriptionApp.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PrescriptionContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("PrescriptionContext") ?? "Data Source=prescriptions.db"));

builder.Services.Configure<RouteOptions>(o => o.LowercaseUrls = true);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
// send every upper-case URL to lower-case
app.Use(async (ctx, next) =>
{
    var path = ctx.Request.Path.Value!;
    if (!string.Equals(path, path.ToLowerInvariant(), StringComparison.Ordinal))
    {
        ctx.Response.Redirect(path.ToLowerInvariant() + ctx.Request.QueryString, true);
        return;
    }
    await next();
});

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
