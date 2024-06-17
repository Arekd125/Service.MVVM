using MediatR;

namespace Service.ViewModel.Service.Queries.GetAllDeviceName
{
    public class GetAllDeviceNameQuery : IRequest<IEnumerable<string>>
    {
    }
}