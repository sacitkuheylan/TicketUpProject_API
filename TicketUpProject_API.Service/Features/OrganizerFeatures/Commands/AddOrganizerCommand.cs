using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketUpProject_API.Domain.Entities;
using TicketUpProject_API.Persistence;

namespace TicketUpProject_API.Service.Features.OrganizerFeatures.Commands
{
    public class AddOrganizerCommand : IRequest<int>
    {
        public string name { get; set; }
        public string address { get; set; }
        public string location { get; set; }
        public string contact { get; set; }

        public class AddOrganizerCommandHandler : IRequestHandler<AddOrganizerCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public AddOrganizerCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(AddOrganizerCommand request, CancellationToken cancellationToken)
            {
                var eventOrganizer = new Organizer();

                eventOrganizer.name = request.name;
                eventOrganizer.address = request.address;
                eventOrganizer.location = request.location;
                eventOrganizer.contact = request.contact;

                _context.Organizers.Add(eventOrganizer);
                await _context.SaveChangesAsync();
                return eventOrganizer.Id;
            }
        }
    }
}
