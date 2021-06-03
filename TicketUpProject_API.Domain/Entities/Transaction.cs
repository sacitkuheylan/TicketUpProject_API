using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketUpProject_API.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public int eventId { get; set; }
        public int userId { get; set; }
        public int price { get; set; }
        public string paymentType { get; set; }
    }
}
