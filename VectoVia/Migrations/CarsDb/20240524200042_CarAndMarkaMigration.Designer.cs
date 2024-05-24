﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using vectovia.Models.Cars;

#nullable disable

namespace vectovia.Migrations.CarsDb
{
    [DbContext(typeof(CarsDbContext))]
    [Migration("20240524200042_CarAndMarkaMigration")]
    partial class CarAndMarkaMigration
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

                    b.Property<int>("MarkaID")
                        .HasColumnType("int");

                    b.Property<string>("Modeli")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Transmisioni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VitiProdhimit")
                        .HasColumnType("int");

                    b.HasKey("Tabelat");

                    b.HasIndex("MarkaID");

                    b.ToTable("CarDBO");
                });

            modelBuilder.Entity("VectoVia_LabCourse.Models.Cars.Model.Marka", b =>
                {
                    b.Property<int>("MarkaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MarkaId"));

                    b.Property<string>("EmriMarkes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MarkaId");

                    b.ToTable("Markat");
                });

            modelBuilder.Entity("VectoVia.Models.Cars.Model.Car", b =>
                {
                    b.HasOne("VectoVia_LabCourse.Models.Cars.Model.Marka", "Marka")
                        .WithMany("CarDBO")
                        .HasForeignKey("MarkaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Marka");
                });

            modelBuilder.Entity("VectoVia_LabCourse.Models.Cars.Model.Marka", b =>
                {
                    b.Navigation("CarDBO");
                });
#pragma warning restore 612, 618
        }
    }
}
