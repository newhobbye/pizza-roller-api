using Microsoft.EntityFrameworkCore;
using RollerPizza.Data.Mappings;
using RollerPizza.Model;

namespace RollerPizza.Data
{
    public class DBContext : DbContext, IDBContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) => Database.EnsureCreated();//se nao houver, cria


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //mapeamento de relação. como não há, somente menção 
            
            modelBuilder.ApplyConfiguration(new PizzaMapping());
            modelBuilder.ApplyConfiguration(new DrinkMapping());
            modelBuilder.ApplyConfiguration(new ClientMapping());
            modelBuilder.ApplyConfiguration(new AddressMapping());
            modelBuilder.ApplyConfiguration(new PaymentMapping());
        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Payment> Payments { get; set; }

    }

    public interface IDBContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
