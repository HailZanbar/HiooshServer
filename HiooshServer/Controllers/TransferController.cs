using Microsoft.AspNetCore.Mvc;
using HiooshServer.Services;
using HiooshServer.Models;

namespace HiooshServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferController : Controller
    {
        private readonly IContactsService _contactsService;
        public TransferController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }
        [HttpPost]
        public IActionResult AddMessage(string from, string to, string content)
        {
            if (!ModelState.IsValid)
            {
                Message message = new Message(int _id, content, false, DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                _contactsService.AddMessage(to, from, message);
                return Created(string.Format("/api/tranfer/{0}", message.id), message);
            }
            return BadRequest();
        }
    }
}
