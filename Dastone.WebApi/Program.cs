using Dastone.CrossCutting.InversionOfControl.Service;
using Dastone.CrossCutting.InversionOfControl.AuctionManagerDbConfig;
using Dastone.CrossCutting.InversionOfControl.AutoMapperConfig;
using Dastone.CrossCutting.InversionOfControl.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddMySqlDependency(builder.Configuration);
builder.Services.AddMySqlRepositoryDependency();
builder.Services.AddServiceDependency();
builder.Services.AddMapperConfiguration();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

builder.Services.UpdateDatabase(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
