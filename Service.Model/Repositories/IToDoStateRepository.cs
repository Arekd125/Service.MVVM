using Service.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Repositories
{
    public interface IToDoStateRepository
    {
        public Task<IEnumerable<ToDoState>> GetAllToDos();

        public Task Create(ToDoState toDoState);

        public Task UpDate(ToDoState toDoState);

        public Task Remove(int Id);
    }
}