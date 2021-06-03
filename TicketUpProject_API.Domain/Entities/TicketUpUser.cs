using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketUpProject_API.Domain.Entities
{
    public class TicketUpUser : BaseEntity
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
    }
}
