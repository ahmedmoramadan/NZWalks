﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NZWalks.API.Data;

#nullable disable

namespace NZWalks.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240704163046_Seeding data")]
    partial class Seedingdata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NZWalks.API.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("64933176-8469-48f2-a7c6-1eef0aba09c4"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("d7cf3178-e752-495c-b3e4-0fbfa11462fc"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("74fc6221-ec69-48a2-b0d9-7c1c71b8451a"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2aa48e14-449e-4c3d-93d7-573bc83565e9"),
                            Code = "AKL",
                            Name = "Auckland",
                            RegionImageUrl = "https://www.aucklandnz.com/sites/build_auckland/files/styles/scale_and_crop_1440x900_/public/media-library/images/Explore%20more/Te%20Puia%20Rotorua%20Hot%20Pools%20%26%20Geysers.jpg"
                        },
                        new
                        {
                            Id = new Guid("b5d76e1e-8d45-4d2a-8d95-cf530f3a40c3"),
                            Code = "WLG",
                            Name = "Wellington"
                        },
                        new
                        {
                            Id = new Guid("d9d3d8e4-b91d-4c6e-9c2d-3f0a41cb8c85"),
                            Code = "CHC",
                            Name = "Christchurch",
                            RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/6/67/Christchurch_%28NZ%29_-_flickr_-_spsmith.jpg"
                        },
                        new
                        {
                            Id = new Guid("a3d3c8f6-c2a1-4a1b-bb1e-8f4e43efc9d2"),
                            Code = "DUD",
                            Name = "Dunedin",
                            RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/f/f2/Dunedin_New_Zealand_01.jpg"
                        });
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Walk", b =>
                {
                    b.HasOne("NZWalks.API.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NZWalks.API.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}