using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RollerPizza.Model;

namespace RollerPizza.Data.Mappings
{
    public class PaymentMapping : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payment");
            builder.HasKey(k => k.PaymentId);
            builder.Property(k => k.PaymentId)
                .HasColumnType("varchar(11)")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.TotalPay)
                .HasColumnType("decimal(38,2)");

            builder.Property(d => d.DateTransaction)
                .HasColumnType("datetime");

            builder.Property(s => s.StatusOrder)
                .HasColumnType("varchar(15)");


            builder.HasMany(p => p.Pizzas) 
                .WithMany(p => p.Payment);

            builder.HasMany(d => d.Drinks)
                .WithMany(d => d.Payment);

            builder.HasOne(pagamento => pagamento.Client)
                .WithMany(cliente => cliente.PaymentItems)
                .HasForeignKey(pagamento => pagamento.CPFId);
                
        }
    }
}
