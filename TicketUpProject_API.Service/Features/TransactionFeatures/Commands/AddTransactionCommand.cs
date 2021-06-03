using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketUpProject_API.Domain.Entities;
using TicketUpProject_API.Persistence;

namespace TicketUpProject_API.Service.Features.TransactionFeatures.Commands
{
    public class AddTransactionCommand : IRequest<int>
    {
        public int eventId { get; set; }
        public int userId { get; set; }
        public int price { get; set; }
        public string paymentType { get; set; }
        public class AddTransactionCommandHandler : IRequestHandler<AddTransactionCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public AddTransactionCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
            {
                var transaction = new Transaction();

                transaction.eventId = request.eventId;
                transaction.userId = request.userId;
                transaction.price = request.price;
                transaction.paymentType = request.paymentType;

                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();
                return transaction.Id;
            }
        }
    }
}
