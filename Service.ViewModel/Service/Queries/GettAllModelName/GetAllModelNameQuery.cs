using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Service.Queries.GettAllModelName
{
    public class GetAllModelNameQuery : IRequest<IEnumerable<string>>
    {
        public string DeviceStateName { get; }

        public GetAllModelNameQuery(string deviceStateName)
        {
            DeviceStateName = deviceStateName;
        }
    }
}