using Microsoft.EntityFrameworkCore;
using Service.Model.DbContexts;
using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Services.ServicesDevice
{
    public class DatabaseDeviceProvider : DatabaseServiceBase, IDeviceProvider
    {
        public DatabaseDeviceProvider(OrdersDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }

        public async Task<DeviceState> GetDevice(int id)
        {
            using (OrdersDbContext context = _dbContextFactory.CreateDbContext())
            {
                var device = await context.DeviceState.FirstAsync(u => u.Id == id);

                return device;
            }
        }

        public async Task<DeviceState> GetDevice(string deviceName)
        {
            using (OrdersDbContext context = _dbContextFactory.CreateDbContext())
            {
                var device = await context.DeviceState.Include(o => o.ModelLists).FirstAsync(u => u.Name == deviceName);

                return device;
            }
        }

        public async Task<IEnumerable<DeviceState>> GetAllDevice()
        {
            using (OrdersDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<DeviceState> DeviceStates = await context.DeviceState.Include(o => o.ModelLists).ToListAsync();

                return DeviceStates;
            }
        }
    }
}