﻿// <auto-generated />
using System;
using HirmudeMaja.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HirmudeMaja.Migrations
{
    [DbContext(typeof(HirmudeMajaContext))]
    [Migration("20220125094254_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HirmudeMaja.Models.Seikleja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Eesnimi")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTime?>("Sisenemisaeg")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Väljumisaeg")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Eesnimi")
                        .IsUnique();

                    b.ToTable("Seikleja");
                });
#pragma warning restore 612, 618
        }
    }
}
