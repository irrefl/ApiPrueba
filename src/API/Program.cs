using DataAccess.Repositories;
using DataAccess.Contracts;
using DataAccess;
using BusinessLogic.Contracts;
using BusinessLogic.Services;
using Microsoft.EntityFrameworkCore;
using DataAccess.Seeds;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string DBUUID = Guid.NewGuid().ToString();
builder.Services.AddDbContext<FruitContext>(opt =>
                opt.UseInMemoryDatabase("FruitList" + DBUUID));

builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
builder.Services.AddScoped<IServiceWrapper, ServiceWrapper>();




builder.Services.AddControllers();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {

        var context = services.GetRequiredService<FruitContext>();
        //    context.Database.Migrate();
        Seed.SeedData(context);

    }
    catch (Exception e)
    {
        Console.WriteLine($"Error {e.ToString()}");
    }
}




if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
