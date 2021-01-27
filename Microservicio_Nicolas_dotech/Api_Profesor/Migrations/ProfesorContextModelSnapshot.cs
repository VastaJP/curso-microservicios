﻿// <auto-generated />
using System;
using Api_Profesor.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api_Profesor.Migrations
{
    [DbContext(typeof(ProfesorContext))]
    partial class ProfesorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Api_Profesor.Model.Profesor", b =>
                {
                    b.Property<int>("ProfesorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Edad")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaIncorporacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("MateriaId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProfesorId");

                    b.ToTable("Datos");
                });
#pragma warning restore 612, 618
        }
    }
}
