using MediatR;

namespace Service.ViewModel.Service.Queries.GettAllModelName
{
    public class GetAllModelNameQuery : IRequest<IEnumerable<string>>
    {
        public string? DeviceName { get; }

        public GetAllModelNameQuery(string? deviceStateName)
        {
            DeviceName = deviceStateName;
        }
    }
}