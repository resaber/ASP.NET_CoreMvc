using Microsoft.EntityFrameworkCore;
using prjCatCoffe.Models; // ← 根據你 DbContext 的命名空間

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

//取得appsettings.json中的連線字串
string? connectionString =
    builder.Configuration.GetConnectionString("CatCafeDBConnection");

//把CatCoffeeDBContext 類別註冊在此
builder.Services.AddDbContext<CatCafeDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Member}/{action=List}")
    .WithStaticAssets();

app.Run();