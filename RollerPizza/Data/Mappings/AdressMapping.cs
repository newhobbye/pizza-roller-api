using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RollerPizza.Model;

namespace RollerPizza.Data.Mappings
{
    public class AdressMapping : IEntityTypeConfiguration<Adress>
    {
        public void Configure(EntityTypeBuilder<Adress> builder)
        {
            builder.ToTable("Adress");

            builder.HasKey(k => k.AdressId);
            builder.Property(k => k.AdressId)
                .HasColumnType("varchar(11)")
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(c => c.CEP)
                .HasColumnType("tinyint(8)")
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
                .HasColumnType("tinyint(10)")
                .IsRequired();

            builder.Property(d => d.Description)
                .HasColumnType("varchar(120)");

            
                
        }
    }
}
