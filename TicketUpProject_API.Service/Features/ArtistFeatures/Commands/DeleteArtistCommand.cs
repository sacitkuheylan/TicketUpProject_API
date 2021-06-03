using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketUpProject_API.Persistence;

namespace TicketUpProject_API.Service.Features.ArtistFeatures.Commands
{
    public class DeleteArtistCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteArtistCommandHandler : IRequestHandler<DeleteArtistCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteArtistCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteArtistCommand request, CancellationToken cancellationToken)
            {
                var artist = await _context.Artists.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                if (artist == null) return default;
                _context.Artists.Remove(artist);
                await _context.SaveChangesAsync();
                return artist.Id;
            }
        }
    }
}
