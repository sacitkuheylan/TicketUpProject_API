using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketUpProject_API.Domain.Entities;
using TicketUpProject_API.Persistence;

namespace TicketUpProject_API.Service.Features.CommentFeatures.Commands
{
    public class AddCommentCommand : IRequest<int> 
    {
        public string title { get; set; }
        public string description { get; set; }
        public int userId { get; set; }
        public int eventId { get; set; }

        public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public AddCommentCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(AddCommentCommand request, CancellationToken cancellationToken)
            {
                var comment = new Comment();

                comment.title = request.title;
                comment.description = request.description;
                comment.userId = request.userId;
                comment.eventId = request.eventId;

                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();
                return comment.Id;
            }
        }
    }
}
