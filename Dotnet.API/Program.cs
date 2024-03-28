using Dotnet.API.Persistances;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var dbConnectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<SimpleEShopDbContext>(options =>
       {
           options
               .UseMySql(
                   dbConnectionString,
                   ServerVersion.AutoDetect(dbConnectionString)
               );
       });

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

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
