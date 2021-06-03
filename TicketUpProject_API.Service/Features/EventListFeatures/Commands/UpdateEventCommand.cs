using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketUpProject_API.Domain.Entities;
using TicketUpProject_API.Persistence;

namespace TicketUpProject_API.Service.Features.EventListFeatures.Commands
{
    public class UpdateEventCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string detail { get; set; }
        public string date { get; set; }
        public int guestCount { get; set; }
        public int guestLimit { get; set; }
        public int VIPLimit { get; set; }
        public string address { get; set; }
        public string location { get; set; }
        public string contacts { get; set; }
        public int price { get; set; }
        public int categoryId { get; set; }
        public string imageURL { get; set; }

        public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateEventCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
            {
                var eventList = _context.EventLists.Where(a => a.Id == request.Id).FirstOrDefault();

                if (eventList == null)
                {
                    return default;
                }
                else
                {
                    eventList.title = request.title;
                    eventList.detail = request.detail;
                    eventList.date = request.date;
                    eventList.guestCount = request.guestCount;
                    eventList.guestLimit = request.guestLimit;
                    eventList.VIPLimit = request.VIPLimit;
                    eventList.address = request.address;
                    eventList.location = request.location;
                    eventList.contacts = request.contacts;
                    eventList.price = request.price;
                    eventList.categoryId = request.categoryId;
                    eventList.imageURL = request.imageURL;
                    

                    _context.EventLists.Update(eventList);
                    await _context.SaveChangesAsync();
                    return eventList.Id;
                }
            }
        }
    }
}
