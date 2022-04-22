﻿// <auto-generated />
using System;
using EventBookingApp.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EventBookingApp.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220422104416_AddFeedbak")]
    partial class AddFeedbak
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DataAcessLayer.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserRole")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("DataAcessLayer.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AreapinCode")
                        .HasColumnType("int");

                    b.Property<int>("BookingStatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfDays")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfPerson")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("VenuType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookingStatusId");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("DataAcessLayer.BookingDetalis", b =>
                {
                    b.Property<int>("BookingDetalisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<int>("FlowerId")
                        .HasColumnType("int");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.HasKey("BookingDetalisId");

                    b.HasIndex("BookingId");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("FlowerId");

                    b.HasIndex("FoodId");

                    b.ToTable("BookingDetalis");
                });

            modelBuilder.Entity("DataAcessLayer.BookingStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BookingStatuses");
                });

            modelBuilder.Entity("DataAcessLayer.Equipment", b =>
                {
                    b.Property<int>("EquipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("EquipmentCost")
                        .HasColumnType("int");

                    b.Property<string>("EquipmentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EquipmentId");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("DataAcessLayer.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("EventCost")
                        .HasColumnType("int");

                    b.Property<string>("EventTypes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("DataAcessLayer.EventGallery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("EventGalleries");
                });

            modelBuilder.Entity("DataAcessLayer.FeedBack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FeedbackType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("FeedBacks");
                });

            modelBuilder.Entity("DataAcessLayer.Flower", b =>
                {
                    b.Property<int>("FlowerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("FlowerCost")
                        .HasColumnType("int");

                    b.Property<string>("FlowerImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlowerType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FlowerId");

                    b.ToTable("Flowers");
                });

            modelBuilder.Entity("DataAcessLayer.Food", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("FoodCost")
                        .HasColumnType("int");

                    b.Property<string>("FoodType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FoodId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("DataAcessLayer.Booking", b =>
                {
                    b.HasOne("DataAcessLayer.BookingStatus", "BookingStatus")
                        .WithMany("Bookings")
                        .HasForeignKey("BookingStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAcessLayer.Event", "Event")
                        .WithMany("Bookings")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAcessLayer.ApplicationUser", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId");

                    b.Navigation("BookingStatus");

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAcessLayer.BookingDetalis", b =>
                {
                    b.HasOne("DataAcessLayer.Booking", null)
                        .WithMany("BookingDetalis")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAcessLayer.Equipment", null)
                        .WithMany("BookingDetalis")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAcessLayer.Flower", null)
                        .WithMany("BookingDetalis")
                        .HasForeignKey("FlowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAcessLayer.Food", null)
                        .WithMany("BookingDetalis")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAcessLayer.EventGallery", b =>
                {
                    b.HasOne("DataAcessLayer.Event", "Event")
                        .WithMany("EventGallery")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("DataAcessLayer.FeedBack", b =>
                {
                    b.HasOne("DataAcessLayer.ApplicationUser", "User")
                        .WithMany("FeedBacks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAcessLayer.ApplicationUser", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("FeedBacks");
                });

            modelBuilder.Entity("DataAcessLayer.Booking", b =>
                {
                    b.Navigation("BookingDetalis");
                });

            modelBuilder.Entity("DataAcessLayer.BookingStatus", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("DataAcessLayer.Equipment", b =>
                {
                    b.Navigation("BookingDetalis");
                });

            modelBuilder.Entity("DataAcessLayer.Event", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("EventGallery");
                });

            modelBuilder.Entity("DataAcessLayer.Flower", b =>
                {
                    b.Navigation("BookingDetalis");
                });

            modelBuilder.Entity("DataAcessLayer.Food", b =>
                {
                    b.Navigation("BookingDetalis");
                });
#pragma warning restore 612, 618
        }
    }
}
