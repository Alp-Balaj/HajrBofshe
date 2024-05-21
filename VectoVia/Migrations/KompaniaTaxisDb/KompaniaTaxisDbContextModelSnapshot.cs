﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VectoVia.Models.KompaniaTaxi;

#nullable disable

namespace VectoVia.Migrations.KompaniaTaxisDb
{
    [DbContext(typeof(KompaniaTaxisDbContext))]
    partial class KompaniaTaxisDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VectoVia.Models.KompaniaTaxi.Model.KompaniaTaxi", b =>
                {
                    b.Property<int>("CompanyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyID"));

                    b.Property<string>("ContactInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kompania")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("QytetiID")
                        .HasColumnType("int");

                    b.Property<string>("Sigurimi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyID");

                    b.HasIndex("QytetiID");

                    b.ToTable("KompaniaTaxis");
                });

            modelBuilder.Entity("VectoVia.Models.KompaniaTaxi.Model.Qyteti", b =>
                {
                    b.Property<int>("QytetiID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QytetiID"));

                    b.Property<string>("emriIQyteti")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QytetiID");

                    b.ToTable("Qyteti");
                });

            modelBuilder.Entity("VectoVia.Models.KompaniaTaxi.Model.KompaniaTaxi", b =>
                {
                    b.HasOne("VectoVia.Models.KompaniaTaxi.Model.Qyteti", "Qyteti")
                        .WithMany("KompaniaTaxis")
                        .HasForeignKey("QytetiID");

                    b.Navigation("Qyteti");
                });

            modelBuilder.Entity("VectoVia.Models.KompaniaTaxi.Model.Qyteti", b =>
                {
                    b.Navigation("KompaniaTaxis");
                });
#pragma warning restore 612, 618
        }
    }
}
