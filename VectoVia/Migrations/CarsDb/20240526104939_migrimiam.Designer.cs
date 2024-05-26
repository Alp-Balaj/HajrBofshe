﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VectoVia.Models.Cars.NewFolder;

#nullable disable

namespace VectoVia.Migrations.CarsDb
{
    [DbContext(typeof(CarsDbContext))]
    [Migration("20240526104939_migrimiam")]
    partial class migrimiam
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VectoVia.Models.Cars.Model.Car", b =>
                {
                    b.Property<int>("Tabelat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Tabelat"));

                    b.Property<string>("Karburanti")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modeli")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Transmisioni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VitiProdhimit")
                        .HasColumnType("int");

                    b.HasKey("Tabelat");

                    b.ToTable("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
