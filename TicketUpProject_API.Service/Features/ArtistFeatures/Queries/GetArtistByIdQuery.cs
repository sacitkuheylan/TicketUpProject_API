using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketUpProject_API.Domain.Entities;
using TicketUpProject_API.Persistence;

namespace TicketUpProject_API.Service.Features.ArtistFeatures.Queries
{
    public class GetArtistByIdQuery : IRequest<Artist>
    {
        public int Id { get; set; }
        public class GetArtistByIdQueryHandler : IRequestHandler<GetArtistByIdQuery, Artist>
        {
            private readonly IApplicationDbContext _context;
            public GetArtistByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Artist> Handle(GetArtistByIdQuery request, CancellationToken cancellationToken)
            {
                var artist = _context.Artists.Where(a => a.Id == request.Id).FirstOrDefault();
                if (artist == null) return null;
                return artist;
            }
        }
    }
}
