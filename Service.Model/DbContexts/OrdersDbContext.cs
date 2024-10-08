﻿using Microsoft.EntityFrameworkCore;
using Service.Model.Entity;
using Servis.Models.OrderModels;

namespace Service.Model.DbContexts
{
    public class OrdersDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<DeviceState> DeviceState { get; set; }
        public DbSet<ModelState> ModelState { get; set; }
        public DbSet<ToDo> ToDo { get; set; }
        public DbSet<ToDoState> ToDoState { get; set; }

        public OrdersDbContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(ed => ed.Contact)
                .WithMany(ec => ec.Order)
                .HasForeignKey(ed => ed.ContactId);

            modelBuilder.Entity<Contact>()
              .Property(x => x.PhoneNumber)
              .IsRequired();

            modelBuilder.Entity<DeviceState>()
                .HasMany(ml => ml.ModelLists)
                .WithOne(dl => dl.DeviceState)
                .HasForeignKey(k => k.DeviceStateId);

            modelBuilder.Entity<ToDo>()
                .HasOne(x => x.Order)
                .WithMany(k => k.ToDo)
                .HasForeignKey(k => k.OrderId);
        }
    }
}