// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace BackEnd.Migrations
{
    [DbContext(typeof(TeretanaContext))]
    partial class TeretanaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("teretanaID")
                        .HasColumnType("int");

                    b.Property<int>("trenerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("clanarinaID");

                    b.HasIndex("teretanaID");

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

                    b.Property<string>("Naziv")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("teretanaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("teretanaID");

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

                    b.Property<int?>("clanID")
                        .HasColumnType("int");

                    b.Property<DateTime>("krajTermina")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("pocetakTermina")
                        .HasColumnType("datetime2");

                    b.Property<int?>("teretanaID")
                        .HasColumnType("int");

                    b.Property<int?>("trenerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("clanID");

                    b.HasIndex("teretanaID");

                    b.HasIndex("trenerID");

                    b.ToTable("Termini");
                });

            modelBuilder.Entity("Models.Trener", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<int>("brlicence")
                        .HasColumnType("int");

                    b.Property<int?>("teretanaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("teretanaID");

                    b.ToTable("Treneri");
                });

            modelBuilder.Entity("Models.Clan", b =>
                {
                    b.HasOne("Models.Clanarina", "clanarina")
                        .WithMany("ClanoviClanarine")
                        .HasForeignKey("clanarinaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Teretana", "teretana")
                        .WithMany()
                        .HasForeignKey("teretanaID");

                    b.HasOne("Models.Trener", "trener")
                        .WithMany("Clanovi")
                        .HasForeignKey("trenerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("clanarina");

                    b.Navigation("teretana");

                    b.Navigation("trener");
                });

            modelBuilder.Entity("Models.Clanarina", b =>
                {
                    b.HasOne("Models.Teretana", "teretana")
                        .WithMany("clanarine")
                        .HasForeignKey("teretanaID");

                    b.Navigation("teretana");
                });

            modelBuilder.Entity("Models.Termin", b =>
                {
                    b.HasOne("Models.Clan", "clan")
                        .WithMany("termin")
                        .HasForeignKey("clanID");

                    b.HasOne("Models.Teretana", "teretana")
                        .WithMany("clanovi")
                        .HasForeignKey("teretanaID");

                    b.HasOne("Models.Trener", "trener")
                        .WithMany("termini")
                        .HasForeignKey("trenerID");

                    b.Navigation("clan");

                    b.Navigation("teretana");

                    b.Navigation("trener");
                });

            modelBuilder.Entity("Models.Trener", b =>
                {
                    b.HasOne("Models.Teretana", "teretana")
                        .WithMany("treneri")
                        .HasForeignKey("teretanaID");

                    b.Navigation("teretana");
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
