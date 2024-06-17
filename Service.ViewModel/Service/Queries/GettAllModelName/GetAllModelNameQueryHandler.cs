using MediatR;
using Service.Model.Repositories;

namespace Service.ViewModel.Service.Queries.GettAllModelName
{
    public class GetAllModelNameQueryHandler : IRequestHandler<GetAllModelNameQuery, IEnumerable<string>>
    {
        private readonly IDeviceStateRepository _deviceStateRepository;

        public GetAllModelNameQueryHandler(IDeviceStateRepository deviceStateRepository)
        {
            _deviceStateRepository = deviceStateRepository;
        }

        public async Task<IEnumerable<string>> Handle(GetAllModelNameQuery request, CancellationToken cancellationToken)
        {

            if (!string.IsNullOrEmpty(request.DeviceName))
            {
                var device = await _deviceStateRepository.GetDevice(request.DeviceName);
                return device.ModelLists.Select(p => p.Name);
            }
            return Enumerable.Empty<string>();
        }
    }
}