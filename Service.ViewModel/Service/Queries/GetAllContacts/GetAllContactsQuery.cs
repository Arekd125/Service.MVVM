using MediatR;
using Service.ViewModel.Dtos;

namespace Service.ViewModel.Service.Queries.GetAllContacts
{
    public class GetAllContactsQuery : IRequest<IEnumerable<ContactDto>>
    {
    }
}