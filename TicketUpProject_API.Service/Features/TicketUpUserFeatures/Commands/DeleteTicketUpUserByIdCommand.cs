using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketUpProject_API.Persistence;

namespace TicketUpProject_API.Service.Features.TicketUpUserFeatures.Commands
{
    public class DeleteTicketUpUserByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteTicketUpUserByIdCommandHandler : IRequestHandler<DeleteTicketUpUserByIdCommand, int> {
            private readonly IApplicationDbContext _context;
            public DeleteTicketUpUserByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteTicketUpUserByIdCommand request, CancellationToken cancellationToken)
            {
                var user = await _context.TicketUpUsers.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                if (user == null) return default;
                _context.TicketUpUsers.Remove(user);
                await _context.SaveChangesAsync();
                return user.Id;
            }
        }
    }
}
