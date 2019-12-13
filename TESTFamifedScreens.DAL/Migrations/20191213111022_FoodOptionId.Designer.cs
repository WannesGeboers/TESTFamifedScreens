﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TESTFamifedScreens.DAL.Context;

namespace TESTFamifedScreens.DAL.Migrations
{
    [DbContext(typeof(FamifedDatabaseContext))]
    [Migration("20191213111022_FoodOptionId")]
    partial class FoodOptionId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TESTFamifedScreens.DAL.Entities.FlowStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FlowStatusMessages");
                });

            modelBuilder.Entity("TESTFamifedScreens.DAL.Entities.FoodOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("FoodOptions");
                });

            modelBuilder.Entity("TESTFamifedScreens.DAL.Entities.FoodRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FlowStatusId")
                        .HasColumnType("int");

                    b.Property<int>("FoodOptionId")
                        .HasColumnType("int");

                    b.Property<bool>("IsThirsty")
                        .HasColumnType("bit");

                    b.Property<int?>("OrderedById")
                        .HasColumnType("int");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RequestById")
                        .HasColumnType("int");

                    b.Property<int?>("ReviewedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeOfOrder")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeOfReview")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrderedById");

                    b.HasIndex("RequestById");

                    b.HasIndex("ReviewedById");

                    b.ToTable("FoodRequests");
                });

            modelBuilder.Entity("TESTFamifedScreens.DAL.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("TESTFamifedScreens.DAL.Entities.FoodRequest", b =>
                {
                    b.HasOne("TESTFamifedScreens.DAL.Entities.Person", "OrderedBy")
                        .WithMany()
                        .HasForeignKey("OrderedById");

                    b.HasOne("TESTFamifedScreens.DAL.Entities.Person", "RequestBy")
                        .WithMany()
                        .HasForeignKey("RequestById");

                    b.HasOne("TESTFamifedScreens.DAL.Entities.Person", "ReviewedBy")
                        .WithMany()
                        .HasForeignKey("ReviewedById");
                });
#pragma warning restore 612, 618
        }
    }
}