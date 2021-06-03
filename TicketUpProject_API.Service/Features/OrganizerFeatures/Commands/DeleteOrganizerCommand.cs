using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketUpProject_API.Persistence;

namespace TicketUpProject_API.Service.Features.OrganizerFeatures.Commands
{
    public class DeleteOrganizerCommand : IRequest<int>
    {

        public int Id { get; set; }
        public class DeleteOrganizerCommandHandler : IRequestHandler<DeleteOrganizerCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteOrganizerCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteOrganizerCommand request, CancellationToken cancellationToken)
            {
                var organizer = await _context.Organizers.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                if (organizer == null) return default;
                _context.Organizers.Remove(organizer);
                await _context.SaveChangesAsync();
                return organizer.Id;
            }
        }

    }
}
