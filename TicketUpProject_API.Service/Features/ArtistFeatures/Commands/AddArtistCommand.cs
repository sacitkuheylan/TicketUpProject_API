using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketUpProject_API.Domain.Entities;
using TicketUpProject_API.Persistence;

namespace TicketUpProject_API.Service.Features.ArtistFeatures.Commands
{
    public class AddArtistCommand : IRequest<int>
    {
        public string title { get; set; }
        public string description { get; set; }

        public class AddArtistCommandHandler : IRequestHandler<AddArtistCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public AddArtistCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(AddArtistCommand request, CancellationToken cancellationToken)
            {
                var artist = new Artist();
                artist.title = request.title;
                artist.description = request.description;

                _context.Artists.Add(artist);
                await _context.SaveChangesAsync();
                return artist.Id;
            }
        }
    }
}
