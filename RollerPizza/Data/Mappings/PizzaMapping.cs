using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RollerPizza.Model;

namespace RollerPizza.Data.Mappings
{
    public class PizzaMapping : IEntityTypeConfiguration<Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza> builder)
        {
            builder.ToTable("Pizza");

            builder.HasKey(c => c.Id);

            builder.Property(p => p.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnType("varchar(300)")
                .IsRequired();

            builder.Property(p => p.Quantity)
                .HasColumnType("tinyint(100)");

            builder.Property(p => p.Value)
                .HasColumnType("decimal(38,2)");

            builder.HasOne(h => h.Payament)
                .WithMany(p => p.Pizzas);

        }
    }
}
