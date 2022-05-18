using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using HiooshServer.Services;
using HiooshServer.Models;

namespace HiooshServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvitationsController : Controller
    {
        private readonly IContactsService _contactsService;

        public InvitationsController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        [HttpPost]
        public IActionResult AddContact([FromBody] JsonElement fields)
        {
            if (!ModelState.IsValid)
            {
                string from = fields.GetProperty("from").ToString();
                string server = fields.GetProperty("server").ToString();
                Contact contact = new Contact(from,from,server);
                 _contactsService.AddContact(from, contact);
                 return Created(string.Format("/api/invitations/{0}", contact.id), contact);
            }
            return BadRequest();
        }
    }
}
