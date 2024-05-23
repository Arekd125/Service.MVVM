using Service.Model.DbContexts;
using Service.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Repositories
{
    public class ToDoRepository : IToDoRepositroy
    {
        protected readonly OrdersDbContextFactory _dbContextFactory;

        public ToDoRepository(OrdersDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task Create(List<ToDo> ToDos)
        {
            using OrdersDbContext dbContext = _dbContextFactory.CreateDbContext();
            {
                dbContext.ToDo.AddRange(ToDos);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}