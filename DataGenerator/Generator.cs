using Bogus;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Service.Model.DbContexts;
using Service.Model.Entity;
using Servis.Models.OrderModels;

namespace DataGenerator;

public class Generator
{
    private static bool _disposed = true;
    private static int _numberGenerate = 1000;

    public static void Seed(OrdersDbContextFactory dbContextFactory)
    {
        if (_disposed == true)
        {
            using OrdersDbContext dbContext = dbContextFactory.CreateDbContext();
            {
                var order = dbContext.Orders.Any();
                if (!order)
                {
                    var locale = "pl";

                    var contactGenerator = new Faker<Contact>(locale)
                              .RuleFor(c => c.Name, f => f.Person.FullName)
                              .RuleFor(c => c.PhoneNumber, f => f.Random.Replace("### ### ###"));

                    var modelStateGenerator = new Faker<ModelState>(locale)
                        .RuleFor(o => o.Name, f => f.Vehicle.Model());

                    var deivceStateGenerator = new Faker<DeviceState>(locale)
                          .RuleFor(o => o.Name, f => f.Vehicle.Manufacturer())
                          .RuleFor(o => o.ModelLists, f => modelStateGenerator.Generate(6));

                    List<ToDoState> toDoStates = new List<ToDoState>
                        {
                            new ToDoState { ToDoName = "Wymiana oleju", Price = 129.99m },
                            new ToDoState { ToDoName = "Rotacja opon", Price = 89.99m },
                            new ToDoState { ToDoName = "Inspekcja hamulców", Price = 149.99m },
                            new ToDoState { ToDoName = "Mycie samochodu", Price = 49.99m },
                            new ToDoState { ToDoName = "Diagnostyka silnika", Price = 299.99m },
                            new ToDoState { ToDoName = "Wymiana akumulatora", Price = 399.99m },
                            new ToDoState { ToDoName = "Wymiana filtra powietrza", Price = 69.99m },
                            new ToDoState { ToDoName = "Ustawienie geometrii kół", Price = 199.99m }
                        };

                    var toDos = new List<ToDo>
                        {
                            new ToDo { ToDoName = "Wymiana oleju", Price = 129.99m },
                            new ToDo { ToDoName = "Rotacja opon", Price = 89.99m },
                            new ToDo { ToDoName = "Inspekcja hamulców", Price = 149.99m },
                            new ToDo { ToDoName = "Mycie samochodu", Price = 49.99m },
                            new ToDo { ToDoName = "Diagnostyka silnika", Price = 299.99m },
                            new ToDo { ToDoName = "Wymiana akumulatora", Price = 399.99m },
                            new ToDo { ToDoName = "Wymiana filtra powietrza", Price = 69.99m }
                        };

                    var toDoGenerator = new Faker<ToDo>(locale)
                       .RuleFor(t => t.ToDoName, f => f.PickRandom(toDos).ToDoName)
                       .RuleFor(t => t.Price, (f, t) => f.Random.Decimal(0.01m, 100m));

                    var usernumber = 0;

                    var orderGenerator = new Faker<Order>(locale)
                            .RuleFor(o => o.Device, f => f.Vehicle.Manufacturer())
                            .RuleFor(o => o.Model, f => f.Vehicle.Model())
                            .RuleFor(o => o.IsFinished, f => f.Random.Bool())
                            .RuleFor(o => o.Contact, f => contactGenerator.Generate())
                            .RuleFor(o => o.ToDo, f => toDoGenerator.Generate(6))
                            .RuleFor(o => o.StartDate, f => f.Date.Past(2))
                            .RuleFor(o => o.OrderNo, f => usernumber++)

                            .RuleFor(o => o.OrderName, (f, o) =>
                             {
                                 string number = o.OrderNo.ToString();
                                 string date = o.StartDate.ToString("dd.MM.yyyy");
                                 return $"Z/{number}/{date}";
                             })
                            .RuleFor(o => o.Cost, (f, o) =>
                             {
                                 return o.ToDo.Sum(item => item.Price);
                             });

                    var orders = orderGenerator.Generate(_numberGenerate);
                    var devices = deivceStateGenerator.Generate(5);

                    dbContext.AddRange(orders);
                    dbContext.AddRange(devices);
                    dbContext.AddRange(toDoStates);

                    dbContext.SaveChanges();
                }
            }
        }
    }
}