﻿// <auto-generated />
using System;
using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Common.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20191022030921_refactorCurrencyObject")]
    partial class refactorCurrencyObject
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Common.Currency", b =>
                {
                    b.Property<int>("RefCode");

                    b.Property<string>("CountryBank")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("RefCode");

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            RefCode = 2,
                            CountryBank = "Argentina",
                            Name = "Dolar Oficial"
                        },
                        new
                        {
                            RefCode = 3,
                            CountryBank = "Argentina",
                            Name = "Dolar Blue"
                        },
                        new
                        {
                            RefCode = 1,
                            CountryBank = "Uruguay",
                            Name = "Dolar Uy"
                        },
                        new
                        {
                            RefCode = 0,
                            CountryBank = "Uruguay",
                            Name = "Peso Argentino"
                        });
                });

            modelBuilder.Entity("Common.Quotation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoinRefCode");

                    b.Property<DateTime>("Date");

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CoinRefCode");

                    b.ToTable("Quotations");
                });

            modelBuilder.Entity("Common.Quotation", b =>
                {
                    b.HasOne("Common.Currency", "Coin")
                        .WithMany()
                        .HasForeignKey("CoinRefCode")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
