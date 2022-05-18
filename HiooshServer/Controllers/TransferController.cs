using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
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
        public IActionResult AddMessage([FromBody] JsonElement fields)
        {
            if (!ModelState.IsValid)
            { 
                string to = fields.GetProperty("to").ToString();
                string from = fields.GetProperty("from").ToString();
                string content = fields.GetProperty("content").ToString();
                List<Message> messages = _contactsService.GetMessages(to, from);

                // the id of the new message
                int id_of_last;
                if (messages.Count == 0)
                {
                    id_of_last = 0;
                }
                else
                {
                    id_of_last = messages[messages.Count - 1].id;
                }

                Message message = new Message(id_of_last + 1, content, false, DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                _contactsService.AddMessage(to, from, message);
                return Created(string.Format("/api/tranfer/{0}", message.id), message);
            }
            return BadRequest();
        }
    }
}
