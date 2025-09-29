using Microsoft.EntityFrameworkCore;
using PrescriptionApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PrescriptionContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("PrescriptionContext") ?? "Data Source=prescriptions.db"));

builder.Services.Configure<RouteOptions>(o => o.LowercaseUrls = true);

// Add services to the container.
builder.Services.AddControllersWithViews();

if (!builder.Environment.IsDevelopment())
{
    var home = Environment.GetEnvironmentVariable("HOME");   
    if (!string.IsNullOrWhiteSpace(home))
    {
        var dataDir = Path.Combine(home, "data");
        Directory.CreateDirectory(dataDir);
    }
}

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PrescriptionContext>();
    db.Database.Migrate(); 
}


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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