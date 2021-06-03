using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TicketUpProject_API.Domain.Settings;
using TicketUpProject_API.Service.Contract;

namespace TicketUpProject_API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Mail")]
    [ApiVersion("1.0")]
    public class MailController : ControllerBase
    {
        private readonly IEmailService mailService;
        public MailController(IEmailService mailService)
        {
            this.mailService = mailService;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] Mail1Request request)
        {
            await mailService.SendEmailAsync(request);
            return Ok();
        }

    }
}