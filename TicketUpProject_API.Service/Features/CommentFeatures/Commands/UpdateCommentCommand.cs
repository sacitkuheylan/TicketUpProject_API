using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketUpProject_API.Persistence;

namespace TicketUpProject_API.Service.Features.CommentFeatures.Commands
{
    public class UpdateCommentCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int userId { get; set; }
        public int eventId { get; set; }

        public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateCommentCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
            {
                var comment = _context.Comments.Where(a => a.Id == request.Id).FirstOrDefault();

                if (comment == null)
                {
                    return default;
                }
                else
                {
                    comment.title = request.title;
                    comment.description = request.description;
                    comment.userId = request.userId;
                    comment.eventId = request.eventId;

                    _context.Comments.Update(comment);
                    await _context.SaveChangesAsync();
                    return comment.Id;
                }
            }
        }
    }
}
