using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketUpProject_API.Persistence;

namespace TicketUpProject_API.Service.Features.TransactionFeatures.Commands
{
    public class UpdateTransactionCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int eventId { get; set; }
        public int userId { get; set; }
        public int price { get; set; }
        public string paymentType { get; set; }

        public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateTransactionCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
            {
                var transactionUpdate = _context.Transactions.Where(a => a.Id == request.Id).FirstOrDefault();

                if (transactionUpdate == null)
                {
                    return default;
                }
                else
                {
                    transactionUpdate.eventId = request.eventId;
                    transactionUpdate.userId = request.userId;
                    transactionUpdate.price = request.price;
                    transactionUpdate.paymentType = request.paymentType;

                    _context.Transactions.Update(transactionUpdate);
                    await _context.SaveChangesAsync();
                    return transactionUpdate.Id;
                }
            }
        }
    }
}
