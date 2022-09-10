﻿// <auto-generated />
using System;
using MediPet.App.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MediPet.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MediPet.App.Dominio.Historia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Alimentacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Antecedentes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<float>("Peso")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Historias");
                });

            modelBuilder.Entity("MediPet.App.Dominio.Mascota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CuidadorId")
                        .HasColumnType("int");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<int?>("HistoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Procedencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<int?>("VeterinarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CuidadorId");

                    b.HasIndex("HistoriaId");

                    b.HasIndex("VeterinarioId");

                    b.ToTable("Mascotas");
                });

            modelBuilder.Entity("MediPet.App.Dominio.Observacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MascotaId")
                        .HasColumnType("int");

                    b.Property<int>("Sintomas")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MascotaId");

                    b.ToTable("Observaciones");
                });

            modelBuilder.Entity("MediPet.App.Dominio.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroContacto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("MediPet.App.Dominio.SugerenciaCuidado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Diagnostico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HistoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Recomendacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HistoriaId");

                    b.ToTable("SugerenciasCuidado");
                });

            modelBuilder.Entity("MediPet.App.Dominio.Cuidador", b =>
                {
                    b.HasBaseType("MediPet.App.Dominio.Persona");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<int>("NumeroMascotas")
                        .HasColumnType("int");

                    b.Property<int>("TiempoMascota")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Cuidador");
                });

            modelBuilder.Entity("MediPet.App.Dominio.Veterinario", b =>
                {
                    b.HasBaseType("MediPet.App.Dominio.Persona");

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreVeterinaria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Registro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Veterinario");
                });

            modelBuilder.Entity("MediPet.App.Dominio.Mascota", b =>
                {
                    b.HasOne("MediPet.App.Dominio.Cuidador", "Cuidador")
                        .WithMany()
                        .HasForeignKey("CuidadorId");

                    b.HasOne("MediPet.App.Dominio.Historia", "Historia")
                        .WithMany()
                        .HasForeignKey("HistoriaId");

                    b.HasOne("MediPet.App.Dominio.Veterinario", "Veterinario")
                        .WithMany()
                        .HasForeignKey("VeterinarioId");

                    b.Navigation("Cuidador");

                    b.Navigation("Historia");

                    b.Navigation("Veterinario");
                });

            modelBuilder.Entity("MediPet.App.Dominio.Observacion", b =>
                {
                    b.HasOne("MediPet.App.Dominio.Mascota", null)
                        .WithMany("ObservacionesImportantes")
                        .HasForeignKey("MascotaId");
                });

            modelBuilder.Entity("MediPet.App.Dominio.SugerenciaCuidado", b =>
                {
                    b.HasOne("MediPet.App.Dominio.Historia", null)
                        .WithMany("Sugerencias")
                        .HasForeignKey("HistoriaId");
                });

            modelBuilder.Entity("MediPet.App.Dominio.Historia", b =>
                {
                    b.Navigation("Sugerencias");
                });

            modelBuilder.Entity("MediPet.App.Dominio.Mascota", b =>
                {
                    b.Navigation("ObservacionesImportantes");
                });
#pragma warning restore 612, 618
        }
    }
}
