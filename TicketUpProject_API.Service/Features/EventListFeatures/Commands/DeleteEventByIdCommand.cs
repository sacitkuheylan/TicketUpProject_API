using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketUpProject_API.Persistence;

namespace TicketUpProject_API.Service.Features.EventListFeatures.Commands
{
    public class DeleteEventByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteEventByIdCommandHandler : IRequestHandler<DeleteEventByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteEventByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteEventByIdCommand request, CancellationToken cancellationToken)
            {
                var eventList = await _context.EventLists.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                if (eventList == null) return default;
                _context.EventLists.Remove(eventList);
                await _context.SaveChangesAsync();
                return eventList.Id;
            }
        }
    }
}
