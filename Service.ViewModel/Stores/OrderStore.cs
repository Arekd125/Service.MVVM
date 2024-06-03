using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Stores
{
    public class OrderStore
    {
        public event Action OrderCreated;

        public event Action<string> OrderEdited;

        public void AddLastOrder()
        {
            OrderCreated?.Invoke();
        }

        public void EditOrder(string orderName)
        {
            OrderEdited?.Invoke(orderName);
        }
    }
}