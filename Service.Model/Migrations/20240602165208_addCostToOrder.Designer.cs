﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Service.Model.DbContexts;

#nullable disable

namespace Service.Model.Migrations
{
    [DbContext(typeof(OrdersDbContext))]
    [Migration("20240602165208_addCostToOrder")]
    partial class addCostToOrder
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Service.Model.Entity.ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Prize")
                        .HasColumnType("TEXT");

                    b.Property<string>("ToDoName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("ToDo");
                });

            modelBuilder.Entity("Service.Model.Entity.ToDoState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Prize")
                        .HasColumnType("TEXT");

                    b.Property<string>("ToDoName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ToDoState");
                });

            modelBuilder.Entity("Servis.Models.OrderModels.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Servis.Models.OrderModels.DeviceState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DeviceState");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Name = "Lenovo"
                        });
                });

            modelBuilder.Entity("Servis.Models.OrderModels.ModelState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DeviceStateId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DeviceStateId");

                    b.ToTable("ModelState");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DeviceStateId = 2,
                            Name = "G503"
                        });
                });

            modelBuilder.Entity("Servis.Models.OrderModels.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Accessories")
                        .HasColumnType("TEXT");

                    b.Property<int>("ContactId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("Cost")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Device")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OrderName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderNo")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Service.Model.Entity.ToDo", b =>
                {
                    b.HasOne("Servis.Models.OrderModels.Order", "Order")
                        .WithMany("ToDo")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Servis.Models.OrderModels.ModelState", b =>
                {
                    b.HasOne("Servis.Models.OrderModels.DeviceState", "DeviceState")
                        .WithMany("ModelLists")
                        .HasForeignKey("DeviceStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeviceState");
                });

            modelBuilder.Entity("Servis.Models.OrderModels.Order", b =>
                {
                    b.HasOne("Servis.Models.OrderModels.Contact", "Contact")
                        .WithMany("Order")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("Servis.Models.OrderModels.Contact", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("Servis.Models.OrderModels.DeviceState", b =>
                {
                    b.Navigation("ModelLists");
                });

            modelBuilder.Entity("Servis.Models.OrderModels.Order", b =>
                {
                    b.Navigation("ToDo");
                });
#pragma warning restore 612, 618
        }
    }
}
