using Microsoft.EntityFrameworkCore;
using Servis.Models.OrderModels;
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
        public DbSet<DeviceList> Devices { get; set; }
        public DbSet<ModelList> Models { get; set; }

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

            modelBuilder.Entity<DeviceList>()
                .HasMany(ml => ml.ModelLists)
                .WithOne(dl => dl.DeviceList)
                .HasForeignKey(k => k.DeviceListId);
        }
    }
}