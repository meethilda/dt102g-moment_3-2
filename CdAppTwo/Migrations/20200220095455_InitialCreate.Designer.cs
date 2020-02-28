﻿// <auto-generated />
using CdAppTwo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CdAppTwo.Migrations
{
    [DbContext(typeof(CdContext))]
    [Migration("20200220095455_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("CdAppTwo.Models.Cd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Artist")
                        .HasColumnType("TEXT");

                    b.Property<string>("CdTitle")
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("CDs");
                });

            modelBuilder.Entity("CdAppTwo.Models.Songs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CdId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Playtime")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SongName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CdId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("CdAppTwo.Models.Songs", b =>
                {
                    b.HasOne("CdAppTwo.Models.Cd", "CD")
                        .WithMany("Songs")
                        .HasForeignKey("CdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
