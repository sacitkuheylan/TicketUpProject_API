using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketUpProject_API.Domain.Entities;
using TicketUpProject_API.Persistence;

namespace TicketUpProject_API.Service.Features.CommentFeatures.Queries
{
    public class GetCommentByIdQuery : IRequest<Comment>
    {
        public int Id { get; set; }
        public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, Comment>
        {
            private readonly IApplicationDbContext _context;
            public GetCommentByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Comment> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
            {
                var comment = _context.Comments.Where(a => a.Id == request.Id).FirstOrDefault();
                if (comment == null) return null;
                return comment;
            }
        }
    }
}
