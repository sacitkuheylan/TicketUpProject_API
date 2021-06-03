using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using TicketUpProject_API.Persistence;
using TicketUpProject_API.Domain.Entities;
using TicketUpProject_API.Domain.Entities;

namespace TicketUpProject_API.Service.Features.TransactionFeatures.Queries
{
    public class GetTransactionByIdQuery : IRequest<Domain.Entities.Transaction>
    {
        public int Id { get; set; }
        public class GetTransactionByIdQueryHandler : IRequestHandler<GetTransactionByIdQuery, Domain.Entities.Transaction>
        {
            private readonly IApplicationDbContext _context;
            public GetTransactionByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Domain.Entities.Transaction> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
            {
                var transactionResult = _context.Transactions.Where(a => a.Id == request.Id).FirstOrDefault();
                if (transactionResult == null) return null;
                return transactionResult;
            }
        }
    }
}
