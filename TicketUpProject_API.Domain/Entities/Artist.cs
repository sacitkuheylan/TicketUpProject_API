using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketUpProject_API.Domain.Entities
{
    public class Artist : BaseEntity
    {
        public string title { get; set; }
        public string description { get; set; }
        public List<EventList> eventLists { get; set; }
    }
}
