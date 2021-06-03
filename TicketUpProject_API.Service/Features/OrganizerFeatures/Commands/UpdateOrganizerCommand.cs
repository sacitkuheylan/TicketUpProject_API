using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketUpProject_API.Persistence;

namespace TicketUpProject_API.Service.Features.OrganizerFeatures.Commands
{
    public class UpdateOrganizerCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string location { get; set; }
        public string contact { get; set; }

        public class UpdateOrganizerCommandHandler : IRequestHandler<UpdateOrganizerCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateOrganizerCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateOrganizerCommand request, CancellationToken cancellationToken)
            {
                var organizer = _context.Organizers.Where(a => a.Id == request.Id).FirstOrDefault();

                if (organizer == null)
                {
                    return default;
                }
                else
                {
                    organizer.name = request.name;
                    organizer.address = request.address;
                    organizer.location = request.location;
                    organizer.contact = request.contact;

                    _context.Organizers.Update(organizer);
                    await _context.SaveChangesAsync();
                    return organizer.Id;
                }
            }
        }
    }
}
