using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketUpProject_API.Persistence;

namespace TicketUpProject_API.Service.Features.ArtistFeatures.Commands
{
    public class UpdateArtistByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }

        public class UpdateArtistByIdHandler : IRequestHandler<UpdateArtistByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateArtistByIdHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateArtistByIdCommand request, CancellationToken cancellationToken)
            {
                var artist = _context.Artists.Where(a => a.Id == request.Id).FirstOrDefault();

                if (artist == null)
                {
                    return default;
                }
                else
                {
                    artist.title = request.title;
                    artist.description = request.description;
                    _context.Artists.Update(artist);
                    await _context.SaveChangesAsync();
                    return artist.Id;
                }
            }
        }
    }
 }

