using Servis.Models.OrderModels;
using System.Data;

namespace Servis.Models.OrderBuilder
{
    public class OrderBuilder
    {
        private Order _order = new Order();

        private string SetOrderName()
        {
            return "Z/" + _order.OrderNo + "/" + _order.StartDate.ToString("MM") + "/" + _order.StartDate.ToString("yyyy");
        }

        public OrderBuilder SetOrderNo(int orderNo)
        {
            _order.OrderNo = orderNo;
            return this;
        }

        public OrderBuilder SetStartDate(DateTime startDate)
        {
            _order.StartDate = startDate;
            return this;
        }

        public OrderBuilder SetContact(Contact contact)
        {
            _order.Contact = contact;
            return this;
        }

        public OrderBuilder SetDevice(string device)
        {
            _order.Device = device;
            return this;
        }

        public OrderBuilder SetModel(string model)
        {
            _order.Model = model;
            return this;
        }

        public OrderBuilder SetDescription(string description)
        {
            _order.Description = description;
            return this;
        }

        public OrderBuilder SetToDo(string toDo)
        {
            _order.ToDo = toDo;
            return this;
        }

        public OrderBuilder SetAccessories(string accessories)
        {
            _order.Accessories = accessories;
            return this;
        }

        public OrderBuilder SetToDO(string toDo)
        {
            _order.ToDo = toDo;
            return this;
        }

        public Order Build()
        {
            _order.OrderName = SetOrderName();
            return _order;
        }
    }
}