using Dastone.CrossCutting.InversionOfControl.Service;
using Dastone.CrossCutting.InversionOfControl.AuctionManagerDbConfig;
using Dastone.CrossCutting.InversionOfControl.AutoMapperConfig;
using Dastone.CrossCutting.InversionOfControl.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMySqlDependency(builder.Configuration);
builder.Services.AddMySqlRepositoryDependency();
builder.Services.AddServiceDependency();
builder.Services.AddMapperConfiguration();

var app = builder.Build();

builder.Services.UpdateDatabase(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
