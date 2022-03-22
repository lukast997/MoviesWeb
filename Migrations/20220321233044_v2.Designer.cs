﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace Movies.Migrations
{
    [DbContext(typeof(MoviesContext))]
    [Migration("20220321233044_v2")]
    partial class v2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BioskopDani", b =>
                {
                    b.Property<int>("DaniBioskopIdBioskopa")
                        .HasColumnType("int");

                    b.Property<int>("DaniBioskopIdDana")
                        .HasColumnType("int");

                    b.HasKey("DaniBioskopIdBioskopa", "DaniBioskopIdDana");

                    b.HasIndex("DaniBioskopIdDana");

                    b.ToTable("BioskopDani");
                });

            modelBuilder.Entity("DaniFilm", b =>
                {
                    b.Property<int>("FilmDaniIdDana")
                        .HasColumnType("int");

                    b.Property<int>("FilmoviDaniIdFilma")
                        .HasColumnType("int");

                    b.HasKey("FilmDaniIdDana", "FilmoviDaniIdFilma");

                    b.HasIndex("FilmoviDaniIdFilma");

                    b.ToTable("DaniFilm");
                });

            modelBuilder.Entity("Models.Bioskop", b =>
                {
                    b.Property<int>("IdBioskopa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdBioskopa");

                    b.ToTable("Bioskop");
                });

            modelBuilder.Entity("Models.Dani", b =>
                {
                    b.Property<int>("IdDana")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdDana");

                    b.ToTable("Dani");
                });

            modelBuilder.Entity("Models.Film", b =>
                {
                    b.Property<int>("IdFilma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Popust")
                        .HasColumnType("int");

                    b.HasKey("IdFilma");

                    b.ToTable("Film");
                });

            modelBuilder.Entity("BioskopDani", b =>
                {
                    b.HasOne("Models.Bioskop", null)
                        .WithMany()
                        .HasForeignKey("DaniBioskopIdBioskopa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Dani", null)
                        .WithMany()
                        .HasForeignKey("DaniBioskopIdDana")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DaniFilm", b =>
                {
                    b.HasOne("Models.Dani", null)
                        .WithMany()
                        .HasForeignKey("FilmDaniIdDana")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmoviDaniIdFilma")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
