using Bogus;
using Service.Model.DbContexts;
using Service.Model.Entity;
using Servis.Models.OrderModels;

namespace DataGenerator
{
    public class Generator
    {
        private static bool _disposed = false;
        private static int _numberGenerate = 12000;

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
                        .RuleFor(t => t.Price, (f, t) => f.Random.Decimal(0.01m, 100m));

                    var usernumber = 0;

                    var orderGenerator = new Faker<Order>(locale)

                            .RuleFor(o => o.Device, f => f.Vehicle.Manufacturer())
                            .RuleFor(o => o.Model, f => f.Vehicle.Model())
                            .RuleFor(o => o.IsFinished, f => f.Random.Bool())
                            .RuleFor(o => o.Contact, f => contactGenerator.Generate())
                            .RuleFor(o => o.ToDo, f => ToDoGenerator.Generate(6))
                            .RuleFor(o => o.StartDate, f => f.Date.Past(2))
                            .RuleFor(o => o.OrderNo, f => usernumber++)
                             .RuleFor(o => o.OrderName, (f, o) =>
                             {
                                 string number = o.OrderNo.ToString();
                                 string date = o.StartDate.ToString("dd.MM.yyyy");
                                 return $"Z/{number}/{date}";
                             });

                    var orders = orderGenerator.Generate(_numberGenerate);

                    dbContext.AddRange(orders);

                    dbContext.SaveChanges();
                }
            }
        }
    }
}