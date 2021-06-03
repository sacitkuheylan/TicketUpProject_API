using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketUpProject_API.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string title { get; set; }
        public string description { get; set; }
        public int userId { get; set; }
        public int eventId { get; set; }
    }
}
