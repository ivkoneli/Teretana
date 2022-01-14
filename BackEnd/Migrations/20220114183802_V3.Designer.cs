﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace BackEnd.Migrations
{
    [DbContext(typeof(TeretanaContext))]
    [Migration("20220114183802_V3")]
    partial class V3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Clan", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("IDTeretane")
                        .HasMaxLength(12)
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("clanarinaID")
                        .HasColumnType("int");

                    b.Property<int>("trenerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("clanarinaID");

                    b.HasIndex("trenerID");

                    b.ToTable("Clan");
                });

            modelBuilder.Entity("Models.Clanarina", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<int>("IDTeretane")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("TeretanaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TeretanaID");

                    b.ToTable("Clanarine");
                });

            modelBuilder.Entity("Models.Teretana", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("ID");

                    b.ToTable("Teretana");
                });

            modelBuilder.Entity("Models.Termin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IDteretane")
                        .HasColumnType("int");

                    b.Property<int?>("TeretanaID")
                        .HasColumnType("int");

                    b.Property<int?>("clanID")
                        .HasColumnType("int");

                    b.Property<DateTime>("krajTermina")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("pocetakTermina")
                        .HasColumnType("datetime2");

                    b.Property<int?>("trenerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TeretanaID");

                    b.HasIndex("clanID");

                    b.HasIndex("trenerID");

                    b.ToTable("Termini");
                });

            modelBuilder.Entity("Models.Trener", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IDTeretane")
                        .HasMaxLength(8)
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Plata")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("TeretanaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TeretanaID");

                    b.ToTable("Treneri");
                });

            modelBuilder.Entity("Models.Clan", b =>
                {
                    b.HasOne("Models.Clanarina", "clanarina")
                        .WithMany("ClanoviClanarine")
                        .HasForeignKey("clanarinaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Trener", "trener")
                        .WithMany("Clanovi")
                        .HasForeignKey("trenerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("clanarina");

                    b.Navigation("trener");
                });

            modelBuilder.Entity("Models.Clanarina", b =>
                {
                    b.HasOne("Models.Teretana", null)
                        .WithMany("clanarine")
                        .HasForeignKey("TeretanaID");
                });

            modelBuilder.Entity("Models.Termin", b =>
                {
                    b.HasOne("Models.Teretana", null)
                        .WithMany("clanovi")
                        .HasForeignKey("TeretanaID");

                    b.HasOne("Models.Clan", "clan")
                        .WithMany("termin")
                        .HasForeignKey("clanID");

                    b.HasOne("Models.Trener", "trener")
                        .WithMany("termini")
                        .HasForeignKey("trenerID");

                    b.Navigation("clan");

                    b.Navigation("trener");
                });

            modelBuilder.Entity("Models.Trener", b =>
                {
                    b.HasOne("Models.Teretana", null)
                        .WithMany("treneri")
                        .HasForeignKey("TeretanaID");
                });

            modelBuilder.Entity("Models.Clan", b =>
                {
                    b.Navigation("termin");
                });

            modelBuilder.Entity("Models.Clanarina", b =>
                {
                    b.Navigation("ClanoviClanarine");
                });

            modelBuilder.Entity("Models.Teretana", b =>
                {
                    b.Navigation("clanarine");

                    b.Navigation("clanovi");

                    b.Navigation("treneri");
                });

            modelBuilder.Entity("Models.Trener", b =>
                {
                    b.Navigation("Clanovi");

                    b.Navigation("termini");
                });
#pragma warning restore 612, 618
        }
    }
}
