using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketUpProject_API.Domain.Entities
{
    public class Organizer : BaseEntity
    {
        public string name { get; set; }
        public string address { get; set; }
        public string location { get; set; }
        public string contact { get; set; }
    }
}
