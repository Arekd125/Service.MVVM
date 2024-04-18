using Service.Model.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Services
{
    public class DatabaseServiceBase
    {
        protected readonly OrdersDbContextFactory _dbContextFactory;

        protected DatabaseServiceBase(OrdersDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
    }
}