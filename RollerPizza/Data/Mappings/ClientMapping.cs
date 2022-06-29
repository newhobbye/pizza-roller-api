using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RollerPizza.Model;

namespace RollerPizza.Data.Mappings
{
    public class ClientMapping : IEntityTypeConfiguration<Client>
    { //modelagem de dados code first
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasKey(k => k.CPFId);

            builder.Property(k => k.CPFId)
                .HasColumnType("varchar(11)")
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(n => n.Name)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(ni => ni.NickName)
                .HasColumnType("varchar(5)")
                .IsRequired();

            builder.Property(p => p.Password)
                .HasColumnType("varchar(9)")
                .HasMaxLength(9)
                .IsRequired();

            builder.Property(em => em.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.HasOne(adress => adress.Adress)
                .WithOne(client => client.Client)
                .HasForeignKey<Client>(client => client.AdressId);

            

        }
    }
}
