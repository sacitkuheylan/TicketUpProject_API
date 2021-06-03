﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketUpProject_API.Domain.Entities;
using TicketUpProject_API.Persistence;

namespace TicketUpProject_API.Service.Features.EventListFeatures.Queries
{
    public class GetEventByIdQuery : IRequest<EventList>
    {
        public int Id { get; set; }
        public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, EventList>
        {
            private readonly IApplicationDbContext _context;
            public GetEventByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<EventList> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
            {
                var eventList = _context.EventLists.Where(a => a.Id == request.Id).FirstOrDefault();
                if (eventList == null) return null;
                return eventList;
            }
        }
    }
}
