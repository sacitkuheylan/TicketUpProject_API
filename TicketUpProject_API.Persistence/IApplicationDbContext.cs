using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TicketUpProject_API.Domain.Entities;

namespace TicketUpProject_API.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Supplier> Suppliers { get; set; }
        DbSet<Artist> Artists { get; set; }
        DbSet<TicketUpUser> TicketUpUsers { get; set; }
        DbSet<EventList> EventLists { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Organizer> Organizers { get; set; }
        DbSet<Transaction> Transactions { get; set; }

        Task<int> SaveChangesAsync();
    }
}
