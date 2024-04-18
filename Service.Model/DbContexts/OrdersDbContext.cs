using Microsoft.EntityFrameworkCore;
using Servis.Models.OrderModels;
using Servis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servis.Models.OrderBuilder;

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

            //var modelLenovoList = new List<ModelState>();

            //modelLenovoList.Add(new ModelState()
            //{
            //    Id = 1,
            //    Name = "Legion",
            //    DeviceStateId = 1
            //}
            //    );
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

            //modelLenovoList.Add(new ModelStateBuilder("Legion").Build());
            //modelLenovoList.Add(new ModelStateBuilder("G580").Build());
            //modelLenovoList.Add(new ModelStateBuilder("Y740").Build());
            //modelLenovoList.Add(new ModelStateBuilder("330-15ISK").Build());

            //var Lenovo = new DeviceStateBuilder("Lenovo", modelLenovoList).Build();

            //var modelHPList = new List<ModelState>();

            //modelHPList.Add(new ModelStateBuilder("250 G5").Build());
            //modelHPList.Add(new ModelStateBuilder("255 G7").Build());
            //modelHPList.Add(new ModelStateBuilder("Omen").Build());
            //modelHPList.Add(new ModelStateBuilder("5325").Build());
            //modelHPList.Add(new ModelStateBuilder("DV6000").Build());

            //var HP = new DeviceStateBuilder("HP", modelHPList).Build();

            //var modelAcerList = new List<ModelState>();

            //modelAcerList.Add(new ModelStateBuilder("Nitro 5").Build());
            //modelAcerList.Add(new ModelStateBuilder("E515").Build());
            //modelAcerList.Add(new ModelStateBuilder("F571").Build());
            //modelAcerList.Add(new ModelStateBuilder("A541").Build());
            //modelAcerList.Add(new ModelStateBuilder("KAAAA").Build());

            //var Acer = new DeviceStateBuilder("Acer", modelAcerList).Build();

            modelBuilder.Entity<ModelState>()
            .HasData(lenovo);
            modelBuilder.Entity<DeviceState>()
             .HasData(Lenovo);
        }
    }
}