using Service.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Repositories
{
    public interface IToDoRepositroy
    {
        public Task Create(List<ToDo> ToDos);
    }
}