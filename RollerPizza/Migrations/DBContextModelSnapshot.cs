﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RollerPizza.Data;

#nullable disable

namespace RollerPizza.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RollerPizza.Model.Adress", b =>
                {
                    b.Property<string>("AdressId")
                        .HasColumnType("varchar(11)");

                    b.Property<sbyte>("CEP")
                        .HasColumnType("tinyint(8)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(120)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<sbyte>("Number")
                        .HasColumnType("tinyint(10)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.HasKey("AdressId");

                    b.ToTable("Adress", (string)null);
                });

            modelBuilder.Entity("RollerPizza.Model.Client", b =>
                {
                    b.Property<string>("CPFId")
                        .HasColumnType("varchar(11)");

                    b.Property<string>("AdressId")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("varchar(9)");

                    b.HasKey("CPFId");

                    b.HasIndex("AdressId")
                        .IsUnique();

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("RollerPizza.Model.Drink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PayamentId")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<sbyte>("Quantity")
                        .HasColumnType("tinyint(100)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(38,2)");

                    b.HasKey("Id");

                    b.HasIndex("PayamentId");

                    b.ToTable("Drink", (string)null);
                });

            modelBuilder.Entity("RollerPizza.Model.Payament", b =>
                {
                    b.Property<string>("PayamentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(11)");

                    b.Property<string>("CPFId")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("DateTransaction")
                        .HasColumnType("datetime");

                    b.Property<string>("StatusOrder")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasKey("PayamentId");

                    b.HasIndex("CPFId");

                    b.ToTable("Payament", (string)null);
                });

            modelBuilder.Entity("RollerPizza.Model.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PayamentId")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<sbyte>("Quantity")
                        .HasColumnType("tinyint(100)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(38,2)");

                    b.HasKey("Id");

                    b.HasIndex("PayamentId");

                    b.ToTable("Pizza", (string)null);
                });

            modelBuilder.Entity("RollerPizza.Model.Client", b =>
                {
                    b.HasOne("RollerPizza.Model.Adress", "Adress")
                        .WithOne("Client")
                        .HasForeignKey("RollerPizza.Model.Client", "AdressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adress");
                });

            modelBuilder.Entity("RollerPizza.Model.Drink", b =>
                {
                    b.HasOne("RollerPizza.Model.Payament", "Payament")
                        .WithMany("Drinks")
                        .HasForeignKey("PayamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Payament");
                });

            modelBuilder.Entity("RollerPizza.Model.Payament", b =>
                {
                    b.HasOne("RollerPizza.Model.Client", "Client")
                        .WithMany("PayamentItems")
                        .HasForeignKey("CPFId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("RollerPizza.Model.Pizza", b =>
                {
                    b.HasOne("RollerPizza.Model.Payament", "Payament")
                        .WithMany("Pizzas")
                        .HasForeignKey("PayamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Payament");
                });

            modelBuilder.Entity("RollerPizza.Model.Adress", b =>
                {
                    b.Navigation("Client")
                        .IsRequired();
                });

            modelBuilder.Entity("RollerPizza.Model.Client", b =>
                {
                    b.Navigation("PayamentItems");
                });

            modelBuilder.Entity("RollerPizza.Model.Payament", b =>
                {
                    b.Navigation("Drinks");

                    b.Navigation("Pizzas");
                });
#pragma warning restore 612, 618
        }
    }
}
