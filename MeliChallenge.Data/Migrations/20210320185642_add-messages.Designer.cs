// <auto-generated />
using System;
using MeliChallenge.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MeliChallenge.Data.Migrations
{
    [DbContext(typeof(MeliDbContext))]
    [Migration("20210320185642_add-messages")]
    partial class addmessages
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("MeLiChallenge.Model.Message", b =>
                {
                    b.Property<int>("IdMessage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("MessageResult")
                        .HasColumnType("text");

                    b.Property<DateTime>("ReceivedTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("IdMessage");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("MeLiChallenge.Model.MessageItem", b =>
                {
                    b.Property<int>("IdMessageItem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("MessageIdMessage")
                        .HasColumnType("integer");

                    b.Property<string[]>("Phrases")
                        .HasColumnType("text[]");

                    b.Property<int?>("SatelliteIdSatelite")
                        .HasColumnType("integer");

                    b.HasKey("IdMessageItem");

                    b.HasIndex("MessageIdMessage");

                    b.HasIndex("SatelliteIdSatelite");

                    b.ToTable("MessageItems");
                });

            modelBuilder.Entity("MeLiChallenge.Model.Satellite", b =>
                {
                    b.Property<int>("IdSatelite")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<double>("PositionX")
                        .HasColumnType("double precision");

                    b.Property<double>("PositionY")
                        .HasColumnType("double precision");

                    b.HasKey("IdSatelite");

                    b.ToTable("Satellites");

                    b.HasData(
                        new
                        {
                            IdSatelite = 1,
                            Name = "Kenobi",
                            PositionX = -500.0,
                            PositionY = -200.0
                        },
                        new
                        {
                            IdSatelite = 2,
                            Name = "Skywalker",
                            PositionX = 100.0,
                            PositionY = -100.0
                        },
                        new
                        {
                            IdSatelite = 3,
                            Name = "Sato",
                            PositionX = 500.0,
                            PositionY = 100.0
                        });
                });

            modelBuilder.Entity("MeLiChallenge.Model.MessageItem", b =>
                {
                    b.HasOne("MeLiChallenge.Model.Message", null)
                        .WithMany("MessageItems")
                        .HasForeignKey("MessageIdMessage");

                    b.HasOne("MeLiChallenge.Model.Satellite", "Satellite")
                        .WithMany()
                        .HasForeignKey("SatelliteIdSatelite");

                    b.Navigation("Satellite");
                });

            modelBuilder.Entity("MeLiChallenge.Model.Message", b =>
                {
                    b.Navigation("MessageItems");
                });
#pragma warning restore 612, 618
        }
    }
}
