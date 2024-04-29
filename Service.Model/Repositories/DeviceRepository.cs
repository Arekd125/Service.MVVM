﻿using Microsoft.EntityFrameworkCore;
using Service.Model.DbContexts;
using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly OrdersDbContextFactory _dbContextFactory;

        public DeviceRepository(OrdersDbContextFactory dbContextFactory)
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

        public async Task<DeviceState> GetDevice(string devicestateName)
        {
            using (OrdersDbContext context = _dbContextFactory.CreateDbContext())
            {
                var device = await context.DeviceState.Include(o => o.ModelLists).FirstAsync(u => u.Name == devicestateName);

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

        public async Task AddModel(ModelState modelState, string deviceStateName)
        {
            using (OrdersDbContext context = _dbContextFactory.CreateDbContext())
            {
                DeviceState device = await context.DeviceState.Include(o => o.ModelLists).FirstAsync(u => u.Name == deviceStateName);

                if (device != null)
                {
                    device.ModelLists.Add(modelState);

                    await context.SaveChangesAsync();
                }
            }
        }
    }
}