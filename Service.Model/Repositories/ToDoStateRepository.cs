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
    public class ToDoStateRepository : IToDoStateRepository
    {
        protected readonly OrdersDbContextFactory _dbContextFactory;

        public ToDoStateRepository(OrdersDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<ToDoState>> GetAllToDoState()
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

        public async Task<ToDoState?> GetById(int id)
        {
            using OrdersDbContext dbContext = _dbContextFactory.CreateDbContext();
            {
                return await dbContext.ToDoState.FirstAsync(x => x.Id == id);
            }
        }

        public async Task UpDate(ToDoState toDoState)
        {
            using OrdersDbContext dbContext = _dbContextFactory.CreateDbContext();
            {
                dbContext.ToDoState.Update(toDoState);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Remove(ToDoState toDoState)
        {
            using OrdersDbContext dbContext = _dbContextFactory.CreateDbContext();
            {
                dbContext.ToDoState.Remove(toDoState);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}