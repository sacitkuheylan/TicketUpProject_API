using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketUpProject_API.Persistence;

namespace TicketUpProject_API.Service.Features.TransactionFeatures.Commands
{
    public class DeleteTransactionCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteTransactionCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
            {
                var transaction = await _context.Transactions.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                if (transaction == null) return default;
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
                return transaction.Id;
            }
        }
    }
}
