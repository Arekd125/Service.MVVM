using Microsoft.EntityFrameworkCore;
using Service.Model.DbContexts;
using Service.Model.Entity;
using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        protected readonly OrdersDbContextFactory _dbContextFactory;

        public ToDoRepository(OrdersDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<ToDoState>> GetAllToDos()
        {
            using OrdersDbContext dbContext = _dbContextFactory.CreateDbContext();
            {
                IEnumerable<ToDoState> toDoState = await dbContext.ToDoState.ToListAsync();

                return toDoState;
            }
        }

        public async Task Create(ToDoState toDoState)
        {
            using OrdersDbContext dbContext = _dbContextFactory.CreateDbContext();
            {
                dbContext.ToDoState.Add(toDoState);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task UpDate(ToDoState toDoState)
        {
            using OrdersDbContext dbContext = _dbContextFactory.CreateDbContext();
            {
                var toDoStateUpdate = await dbContext.ToDoState.FirstOrDefaultAsync(x => x.Id == toDoState.Id);

                if (toDoStateUpdate != null)
                {
                    toDoStateUpdate.ToDoName = toDoState.ToDoName;
                    toDoStateUpdate.Prize = toDoState.Prize;
                }
                await dbContext.SaveChangesAsync();
            }
        }
    }
}