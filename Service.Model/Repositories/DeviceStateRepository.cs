using Microsoft.EntityFrameworkCore;
using Service.Model.DbContexts;
using Servis.Models.OrderModels;

namespace Service.Model.Repositories
{
    public class DeviceStateRepository : IDeviceStateRepository
    {
        private readonly OrdersDbContextFactory _dbContextFactory;

        public DeviceStateRepository(OrdersDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateDevice(DeviceState deviceState)
        {
            using OrdersDbContext context = _dbContextFactory.CreateDbContext();
            {
                context.DeviceState.Add(deviceState);
                await context.SaveChangesAsync();
            }
        }

        public async Task<DeviceState> GetDevice(string devicestateName)
        {
            using OrdersDbContext context = _dbContextFactory.CreateDbContext();
            {
                var device = await context.DeviceState.Include(o => o.ModelLists).FirstAsync(u => u.Name == devicestateName);

                return device;
            }
        }

        public async Task<IEnumerable<DeviceState>> GetAllDevice()
        {
            using OrdersDbContext context = _dbContextFactory.CreateDbContext();
            {
                IEnumerable<DeviceState> DeviceStates = await context.DeviceState.Include(o => o.ModelLists).ToListAsync();

                return DeviceStates;
            }
        }

        public async Task AddModel(ModelState modelState, string deviceStateName)
        {
            using OrdersDbContext context = _dbContextFactory.CreateDbContext();
            {
                DeviceState device = await context.DeviceState.Include(o => o.ModelLists).FirstAsync(u => u.Name == deviceStateName);

                device.ModelLists.Add(modelState);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteDevice(string deviceStateName)
        {
            using OrdersDbContext context = _dbContextFactory.CreateDbContext();
            {
                DeviceState device = await context.DeviceState.Include(o => o.ModelLists).FirstAsync(u => u.Name == deviceStateName);

                context.DeviceState.Remove(device);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteModel(string deviceStateName, string modeleStateName)
        {
            using OrdersDbContext context = _dbContextFactory.CreateDbContext();
            {
                DeviceState device = await context.DeviceState.Include(o => o.ModelLists).FirstAsync(u => u.Name == deviceStateName);

                ModelState model = device.ModelLists.First(u => u.Name == modeleStateName);

                device.ModelLists.Remove(model);

                await context.SaveChangesAsync();
            }
        }
    }
}