// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RamenRater.Models;

namespace RamenRater.Migrations
{
    [DbContext(typeof(RamenRaterContext))]
    partial class RamenRaterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasData(
                        new
                        {
                            RamenId = 1,
                            Description = "Soy base, Pork Broth, and Pork Belly",
                            Location = "Portland, OR",
                            Rating = 5,
                            Restaurant = "Wu-Rons",
                            Review = "I loved the tonkotsu broth and the pork belly.",
                            Type = "Tonkotsu"
                        },
                        new
                        {
                            RamenId = 2,
                            Description = "Chiken and fish broth, topped with cha shu pork",
                            Location = "Portland, OR",
                            Rating = 5,
                            Restaurant = "Hapa Ramen",
                            Review = "The broth is divine",
                            Type = "Shoyu"
                        },
                        new
                        {
                            RamenId = 3,
                            Description = "spice miso tare and pork broth with ginger pork crumbles",
                            Location = "Portland, OR",
                            Rating = 5,
                            Restaurant = "Afuri",
                            Review = "Super rich and delicious",
                            Type = "Tonkotsu"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
