using Microsoft.AspNetCore.Mvc;
using HiooshServer.Services;
using HiooshServer.Models;

namespace HiooshServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly IContactsService _contactsService;

        public ContactsController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        // return the contacts of the user
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // need to fix the async
            return Json(_contactsService.GetAllContacts());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
        {
           if (!ModelState.IsValid)
            {
                _contactsService.AddContact(contact);
                return Created(string.Format("/api/contacts/{0}", contact.Id), contact);
            }
           return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, string nickname, string image, List<Message> chat)
        {
            if (ModelState.IsValid)
            {
                _contactsService.UpdateContact(id, nickname, image, chat);
                return NoContent();

            }
            return BadRequest();
        }

        [HttpDelete("{id")]
        public IActionResult Delete(string id)
        {
            _contactsService.RemoveContact(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Json(_contactsService.GetContact(id));
        }

        // need to check how to add the "messages" to the url

        [HttpGet("{id}")]
        public IActionResult GetMessages(string id)
        {
            return Json(_contactsService.getMessages(id));
        }
        [HttpPost("{id}")]
        public IActionResult AddMessage(string id, Message message)
        {
            if (!ModelState.IsValid)
            {
                _contactsService.addMessage(id, message);
                return NoContent();
            }
            return BadRequest();
        }

    }
}
