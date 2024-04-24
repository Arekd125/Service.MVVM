using Service.Model.DbContexts;
using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Services.ServicesDevice
{
    public class DatabaseDeviceCreator : IDeviceCreator
    {
        private readonly OrdersDbContextFactory _dbContextFactory;

        public DatabaseDeviceCreator(OrdersDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
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