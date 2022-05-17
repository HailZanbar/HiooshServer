using Microsoft.AspNetCore.Mvc;
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
        public IActionResult AddContact(string from, string to, string server)
        {
            if (!ModelState.IsValid)
            {
                Contact contact = new Contact(from,from,server);
                 _contactsService.AddContact(from, contact);
                 return Created(string.Format("/api/invitations/{0}", contact.id), contact);
            }
            return BadRequest();
        }
    }
}
