using Microsoft.EntityFrameworkCore;
using RollerPizza.Data;
using RollerPizza.Data.Dao;
using RollerPizza.Model;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("ContextConnection");


// Add services to the container.
builder.Services.AddDbContext<DBContext>(db => db.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<DBContext>();
builder.Services.AddTransient<IItemDao<Pizza>, PizzaDao>();
builder.Services.AddTransient<IItemDao<Drink>, DrinkDao>();

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
