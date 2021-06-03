using AutoMapper;
using TicketUpProject_API.Domain.Entities;
using TicketUpProject_API.Infrastructure.ViewModel;

namespace TicketUpProject_API.Infrastructure.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerModel, Customer>()
                .ForMember(dest => dest.Id,
                        opt => opt.MapFrom(src => src.CustomerId))
                .ReverseMap();
        }
    }
}
