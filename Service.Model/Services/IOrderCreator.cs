using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Services
{
    public interface IOrderCreator
    {
        Task CreateOrder(Order order);
    }
}