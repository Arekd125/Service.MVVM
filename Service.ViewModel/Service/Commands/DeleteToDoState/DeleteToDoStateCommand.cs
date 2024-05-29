using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Service.Commands.DeleteToDoState
{
    public class DeleteToDoStateCommand : IRequest
    {
        public int Id { get; }

        public DeleteToDoStateCommand(int id)
        {
            Id = id;
        }
    }
}