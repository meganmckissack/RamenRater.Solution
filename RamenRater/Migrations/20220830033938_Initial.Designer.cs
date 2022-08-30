﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RamenRater.Models;

namespace RamenRater.Migrations
{
    [DbContext(typeof(RamenRaterContext))]
    [Migration("20220830033938_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("RamenRater.Models.Ramen", b =>
                {
                    b.Property<int>("RamenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Location")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Restaurant")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Review")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("RamenId");

                    b.ToTable("Ramens");
                });
#pragma warning restore 612, 618
        }
    }
}