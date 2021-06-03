using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketUpProject_API.Persistence;

namespace TicketUpProject_API.Service.Features.CommentFeatures.Commands
{
    public class DeleteCommentCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteCommentCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
            {
                var comment = await _context.Comments.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                if (comment == null) return default;
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
                return comment.Id;
            }
        }
    }
}
