﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vieru_Marina_Turism.Data;

#nullable disable

namespace Vieru_Marina_Turism.Migrations
{
    [DbContext(typeof(Vieru_Marina_TurismContext))]
    partial class Vieru_Marina_TurismContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Vieru_Marina_Turism.Models.Favourite", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("HolidayID")
                        .HasColumnType("int");

                    b.Property<int?>("MemberID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("HolidayID")
                        .IsUnique()
                        .HasFilter("[HolidayID] IS NOT NULL");

                    b.HasIndex("MemberID");

                    b.ToTable("Favourite");
                });

            modelBuilder.Entity("Vieru_Marina_Turism.Models.Flight", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("AirlineName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Arrival")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Departure")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("Vieru_Marina_Turism.Models.Holiday", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("datetime2");

                    b.Property<string>("Destinations")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FavouriteID")
                        .HasColumnType("int");

                    b.Property<int?>("FlightID")
                        .HasColumnType("int");

                    b.Property<int>("Guests")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("ID");

                    b.HasIndex("FlightID");

                    b.ToTable("Holiday");
                });

            modelBuilder.Entity("Vieru_Marina_Turism.Models.Member", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("Vieru_Marina_Turism.Models.Favourite", b =>
                {
                    b.HasOne("Vieru_Marina_Turism.Models.Holiday", "Holiday")
                        .WithOne("Favourite")
                        .HasForeignKey("Vieru_Marina_Turism.Models.Favourite", "HolidayID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Vieru_Marina_Turism.Models.Member", "Member")
                        .WithMany("Favourites")
                        .HasForeignKey("MemberID");

                    b.Navigation("Holiday");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Vieru_Marina_Turism.Models.Holiday", b =>
                {
                    b.HasOne("Vieru_Marina_Turism.Models.Flight", "Flight")
                        .WithMany("Holidays")
                        .HasForeignKey("FlightID");

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("Vieru_Marina_Turism.Models.Flight", b =>
                {
                    b.Navigation("Holidays");
                });

            modelBuilder.Entity("Vieru_Marina_Turism.Models.Holiday", b =>
                {
                    b.Navigation("Favourite");
                });

            modelBuilder.Entity("Vieru_Marina_Turism.Models.Member", b =>
                {
                    b.Navigation("Favourites");
                });
#pragma warning restore 612, 618
        }
    }
}
