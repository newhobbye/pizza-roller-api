﻿using Microsoft.EntityFrameworkCore;
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

            builder.Property(d => d.DateTransaction)
                .HasColumnType("datetime");

            builder.Property(s => s.StatusOrder)
                .HasColumnType("varchar(15)");


            builder.HasMany(p => p.Pizzas)
                .WithOne(p => p.Payament);

            builder.HasMany(d => d.Drinks)
                .WithOne(d => d.Payament);

            builder.HasOne(pagamento => pagamento.Client)
                .WithMany(cliente => cliente.PayamentItems)
                .HasForeignKey(pagamento => pagamento.CPFId);
                
        }
    }
}