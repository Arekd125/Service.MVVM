using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Stores
{
    public class ToDoStore
    {
        public event Action ToDoAction;

        public void AddTodo()
        {
            ToDoAction?.Invoke();
        }

        public void DeleteTodo()
        {
            ToDoAction?.Invoke();
        }
    }
}