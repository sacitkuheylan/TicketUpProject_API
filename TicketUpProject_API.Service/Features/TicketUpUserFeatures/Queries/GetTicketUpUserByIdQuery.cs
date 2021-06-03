using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketUpProject_API.Domain.Entities;
using TicketUpProject_API.Persistence;

namespace TicketUpProject_API.Service.Features.TicketUpUserFeatures.Queries
{
    public class GetTicketUpUserByIdQuery : IRequest<TicketUpUser>
    {
        public int Id { get; set; }
        public class GetTicketUpUserByIdQueryHandler : IRequestHandler<GetTicketUpUserByIdQuery, TicketUpUser>
        {
            private readonly IApplicationDbContext _context;
            public GetTicketUpUserByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<TicketUpUser> Handle(GetTicketUpUserByIdQuery request, CancellationToken cancellationToken)
            {
                var user = _context.TicketUpUsers.Where(a => a.Id == request.Id).FirstOrDefault();
                if (user == null) return null;
                return user;
            }
        }
    }
}
