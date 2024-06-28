using Microsoft.AspNetCore.Mvc;
using SmtpMailApi.Models;
using SmtpMailApi.Services;

namespace SmtpMailApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly MailService _mailService;

        public MailController(MailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromBody] MailRequest mailRequest)
        {
            if (ModelState.IsValid)
            {
                await _mailService.SendEmailAsync(mailRequest);
                return Ok(new { message = "Email sent successfully!" });
            }

            return BadRequest(ModelState);
        }
    }
}
