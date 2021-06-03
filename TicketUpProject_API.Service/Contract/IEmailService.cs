using System.Threading.Tasks;
using TicketUpProject_API.Domain.Settings;

namespace TicketUpProject_API.Service.Contract
{
    public interface IEmailService
    {
        Task SendEmailAsync(Mail1Request mailRequest);

    }
}
