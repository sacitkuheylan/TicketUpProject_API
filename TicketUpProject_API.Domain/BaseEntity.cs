using System.ComponentModel.DataAnnotations;

namespace TicketUpProject_API.Domain
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
