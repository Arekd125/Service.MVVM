using Microsoft.EntityFrameworkCore;
using Service.Model.DbContexts;

namespace Service.Model.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        protected readonly OrdersDbContextFactory _dbContextFactory;

        public ToDoRepository(OrdersDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task Remove(int OrderId)
        {
            using OrdersDbContext dbContext = _dbContextFactory.CreateDbContext();
            {
                var toDos = await dbContext.ToDo.Where(o => o.OrderId == OrderId).ToListAsync();
                dbContext.ToDo.RemoveRange(toDos);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}