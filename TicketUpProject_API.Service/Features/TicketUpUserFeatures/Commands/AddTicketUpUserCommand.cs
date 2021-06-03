using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketUpProject_API.Domain.Entities;
using TicketUpProject_API.Persistence;

namespace TicketUpProject_API.Service.Features.TicketUpUserFeatures.Commands
{
    public class AddTicketUpUserCommand : IRequest<int>
    {
        public string username { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public string events { get; set; }
        public string eventsHistory { get; set; }
        public int points { get; set; }
        public string phoneNumber { get; set; }
        public string favorites { get; set; }
        public string profilePhotoURL { get; set; }

        public class AddTicketUpUserCommandHandler : IRequestHandler<AddTicketUpUserCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public AddTicketUpUserCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(AddTicketUpUserCommand request, CancellationToken cancellationToken)
            {
                var user = new TicketUpUser();

                user.username = request.username;
                user.name = request.name;
                user.surname = request.surname;
                user.mail = request.mail;
                user.password = request.password;
                user.events = request.events;
                user.eventsHistory = request.eventsHistory;
                user.points = request.points;
                user.phoneNumber = request.phoneNumber;
                user.favorites = request.phoneNumber;
                user.favorites = request.favorites;
                user.profilePhotoURL = request.profilePhotoURL;
                
                _context.TicketUpUsers.Add(user);
                await _context.SaveChangesAsync();
                return user.Id;
            }
        }
    }
}
