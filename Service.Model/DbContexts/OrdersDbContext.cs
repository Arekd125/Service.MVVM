﻿using Microsoft.EntityFrameworkCore;
using Servis.Models.OrderModels;
using Servis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.DbContexts
{
    public class OrdersDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<DeviceState> DeviceState { get; set; }
        public DbSet<ModelState> ModelState { get; set; }

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

            var lenovo = new ModelState()
            {
                Id = 1,
                Name = "G503",
                DeviceStateId = 2
            };

            var Lenovo = new DeviceState()
            {
                Id = 2,
                Name = "Lenovo"
            };

            modelBuilder.Entity<ModelState>()
            .HasData(lenovo);
            modelBuilder.Entity<DeviceState>()
             .HasData(Lenovo);
        }
    }
}