using Service.Model.DbContexts;
using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Services.ServicesDevice
{
    public class DatabaseDeviceCreator : DatabaseServiceBase, IDeviceCreator
    {
        public DatabaseDeviceCreator(OrdersDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }

        public async Task CreateDevice(DeviceState deviceState)
        {
            using (OrdersDbContext context = _dbContextFactory.CreateDbContext())
            {
                context.DeviceState.Add(deviceState);
                await context.SaveChangesAsync();
            }
        }
    }
}