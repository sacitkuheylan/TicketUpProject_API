using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketUpProject_API.Domain.Entities;
using TicketUpProject_API.Persistence;

namespace TicketUpProject_API.Service.Features.OrganizerFeatures.Queries
{
    public class GetOrganizerByIdQuery : IRequest<Organizer>
    {
        public int Id { get; set; }
        public class GetOrganizerByIdQueryHandler : IRequestHandler<GetOrganizerByIdQuery, Organizer>
        {
            private readonly IApplicationDbContext _context;
            public GetOrganizerByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Organizer> Handle(GetOrganizerByIdQuery request, CancellationToken cancellationToken)
            {
                var organizer = _context.Organizers.Where(a => a.Id == request.Id).FirstOrDefault();
                if (organizer == null) return null;
                return organizer;
            }
        }
    }
}
