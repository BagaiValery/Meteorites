﻿// <auto-generated />
using System;
using Meteorites.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Meteorites.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230213092925_addMeteorites")]
    partial class addMeteorites
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Meteorites.Models.GeoDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("coordinateX")
                        .HasColumnType("real");

                    b.Property<float>("coordinateY")
                        .HasColumnType("real");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GeoDB");
                });

            modelBuilder.Entity("Meteorites.Models.MeteoriteViewModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("computed_region_cbhk_fwbd")
                        .HasColumnType("int");

                    b.Property<int?>("computed_region_nnqa_25f4")
                        .HasColumnType("int");

                    b.Property<string>("fall")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("geolocationId")
                        .HasColumnType("int");

                    b.Property<float?>("mass")
                        .HasColumnType("real");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nametype")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("recclass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("reclat")
                        .HasColumnType("real");

                    b.Property<float?>("reclong")
                        .HasColumnType("real");

                    b.Property<DateTime?>("year")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("geolocationId");

                    b.ToTable("Meteorites");
                });

            modelBuilder.Entity("Meteorites.Models.MeteoriteViewModel", b =>
                {
                    b.HasOne("Meteorites.Models.GeoDB", "geolocation")
                        .WithMany()
                        .HasForeignKey("geolocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("geolocation");
                });
#pragma warning restore 612, 618
        }
    }
}
