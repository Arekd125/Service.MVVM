using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Interfaces
{
    public interface IOrderRepository
    {
        public Task Create(Order order);

        public Task<IEnumerable<Order>> GetAllOrders();

        public Task<Order> GetLastOrder();
    }
}