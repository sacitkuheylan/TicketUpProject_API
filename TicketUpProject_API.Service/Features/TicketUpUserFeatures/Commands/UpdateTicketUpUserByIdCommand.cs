using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketUpProject_API.Persistence;

namespace TicketUpProject_API.Service.Features.TicketUpUserFeatures.Commands
{
    public class UpdateTicketUpUserByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
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

        public class UpdateTicketUpUserByIdCommandHandler : IRequestHandler<UpdateTicketUpUserByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateTicketUpUserByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateTicketUpUserByIdCommand request, CancellationToken cancellationToken)
            {
                var user = _context.TicketUpUsers.Where(a => a.Id == request.Id).FirstOrDefault();

                if (user == null)
                {
                    return default;
                }
                else
                {

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

                    _context.TicketUpUsers.Update(user);
                    await _context.SaveChangesAsync();
                    return user.Id;
                }
            }
        }
    }
}
