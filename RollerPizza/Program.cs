using Microsoft.EntityFrameworkCore;
using RollerPizza.Data;
using RollerPizza.Data.Dao;
using RollerPizza.Model;
using RollerPizza.Service;
using RollerPizza.Service.Use_Case;


var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("ContextConnection");


// Add services to the container.
#region"Configuração de contexto"
builder.Services.AddDbContext<DBContext>(db => db.UseLazyLoadingProxies()
.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
#endregion

//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region"Dependencia do contexto"
builder.Services.AddScoped<DBContext>();
#endregion

#region"Dependencias de Dao"
builder.Services.AddScoped<IItemDao<Pizza>, PizzaDao>();
builder.Services.AddScoped<IItemDao<Drink>, DrinkDao>();
builder.Services.AddScoped<ClientDao>();
builder.Services.AddScoped<AddressDao>();
builder.Services.AddScoped<PaymentDao>();
#endregion

#region"Dependencias de Manipuladores de dados"
builder.Services.AddScoped<DrinkHandler>();
builder.Services.AddScoped<PizzaHandler>();
builder.Services.AddScoped<AddressHandler>();
builder.Services.AddScoped<ClientHandler>();
builder.Services.AddScoped<PaymentHandler>();
#endregion

#region"Dependencias de Serviços"
builder.Services.AddScoped<ShoppingKartService>();
#endregion

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
