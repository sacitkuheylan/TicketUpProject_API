using System.ComponentModel.DataAnnotations;

namespace TicketUpProject_API.Domain.Auth
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
