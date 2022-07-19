using Microsoft.EntityFrameworkCore;
using RollerPizza.Data;
using RollerPizza.Data.Dao;
using RollerPizza.Model;
using RollerPizza.Service;
using RollerPizza.Service.Use_Case;
using Microsoft.AspNetCore.Authentication;

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


var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

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

#region"Dependencia de Autenticação de login"
builder.Services.AddAuthentication("Identity.Login")
    .AddCookie("Identity.Login", config =>
    {
        config.Cookie.Name = "Identity.Login";
        config.LoginPath = "/api/pizza/login";
        config.AccessDeniedPath = "/api/pizza/login";
        config.ExpireTimeSpan = TimeSpan.FromDays(1);
    });
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region"Definir para usar autenticação"
app.UseAuthentication();
#endregion

app.UseAuthorization();

app.MapControllers();

app.Run();
