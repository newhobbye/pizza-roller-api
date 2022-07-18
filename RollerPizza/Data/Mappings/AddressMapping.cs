using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RollerPizza.Model;

namespace RollerPizza.Data.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");

            builder.HasKey(k => k.AddressId);
            builder.Property(k => k.AddressId)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(c => c.CEP)
                .HasColumnType("varchar(8)")
                .IsRequired();

            builder.Property(c => c.City)
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder.Property(d => d.District)
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder.Property(s => s.Street)
                .HasColumnType("varchar(25)")
                .IsRequired();

            builder.Property(n => n.Number)
                .HasColumnType("smallint(10)")
                .IsRequired();

            builder.Property(d => d.Description)
                .HasColumnType("varchar(120)");

            builder.HasOne(a => a.Client)
                .WithOne(c => c.Adress)
                .OnDelete(DeleteBehavior.Cascade); //Obriga que ao deletar um cliente, o seu endereço seja deletado
        }
    }
}
