using Bogus;
using Service.Model.DbContexts;
using Service.Model.Entity;
using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator
{
    public class Generator
    {
        private static bool _disposed = false;

        public static void Seed(OrdersDbContextFactory dbContextFactory)
        {
            if (_disposed == true)
            {
                using OrdersDbContext dbContext = dbContextFactory.CreateDbContext();
                {
                    var locale = "pl";

                    var contactGenerator = new Faker<Contact>(locale)
                              .RuleFor(c => c.Name, f => f.Person.FullName)
                              .RuleFor(c => c.PhoneNumber, f => f.Random.Replace("### ### ###"));

                    var ToDoGenerator = new Faker<ToDo>(locale)
                        .RuleFor(t => t.ToDoName, f => f.Hacker.IngVerb())
                        .RuleFor(t => t.Price, (f, t) => f.Random.Decimal(0.01M, 100M));

                    var orderGenerator = new Faker<Order>(locale)
                        .RuleFor(o => o.OrderName, f => f.Random.Replace("Z/**********"))
                        .RuleFor(o => o.Device, f => f.Vehicle.Manufacturer())
                        .RuleFor(o => o.Model, f => f.Vehicle.Model())
                        .RuleFor(o => o.IsFinished, f => f.Random.Bool())
                        .RuleFor(o => o.Contact, f => contactGenerator.Generate())
                        .RuleFor(o => o.ToDo, f => ToDoGenerator.Generate(6))
                        .RuleFor(o => o.StartDate, f => f.Date.Past(60));

                    var orders = orderGenerator.Generate(10000);

                    dbContext.AddRange(orders);

                    dbContext.SaveChanges();
                }
            }
        }
    }
}