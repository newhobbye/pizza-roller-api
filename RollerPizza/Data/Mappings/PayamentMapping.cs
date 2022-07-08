using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RollerPizza.Model;

namespace RollerPizza.Data.Mappings
{
    public class PayamentMapping : IEntityTypeConfiguration<Payament>
    {
        public void Configure(EntityTypeBuilder<Payament> builder)
        {
            builder.ToTable("Payament");
            builder.HasKey(k => k.PayamentId);
            builder.Property(k => k.PayamentId)
                .HasColumnType("varchar(11)")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.TotalPay)
                .HasColumnType("decimal(38,2)");

            builder.Property(d => d.DateTransaction)
                .HasColumnType("datetime");

            builder.Property(s => s.StatusOrder)
                .HasColumnType("varchar(15)");


            builder.HasMany(p => p.Pizzas) 
                .WithMany(p => p.Payament);

            builder.HasMany(d => d.Drinks)
                .WithMany(d => d.Payament);

            builder.HasOne(pagamento => pagamento.Client)
                .WithMany(cliente => cliente.PayamentItems)
                .HasForeignKey(pagamento => pagamento.CPFId);
                
        }
    }
}
