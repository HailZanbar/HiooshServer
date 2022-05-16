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
        public IActionResult Index(string userID)
        {
            // need to fix the async
            return Json(_contactsService.GetAllContacts(userID));
        }

        [HttpPost]
        public IActionResult Create(string userID, Contact contact)
        {
           if (!ModelState.IsValid)
            {
                _contactsService.AddContact(userID, contact);
                return Created(string.Format("/api/contacts/{0}", contact.Id), contact);
            }
           return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string userID, string id, string nickname, string image, List<Message> chat)
        {
            if (ModelState.IsValid)
            {
                _contactsService.UpdateContact(userID, id, nickname, image, chat);
                return NoContent();

            }
            return BadRequest();
        }

        [HttpDelete("{id")]
        public IActionResult Delete(string userID, string id)
        {
            _contactsService.RemoveContact(userID, id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult Get(string userID, string id)
        {
            return Json(_contactsService.GetContact(userID, id));
        }

        // need to check how to add the "messages" to the url
        [Route("api/contacts/{id}/messages")]
        [HttpGet("{id}")]
        public IActionResult GetMessages(string userID, string id)
        {
            return Json(_contactsService.GetMessages(userID, id));
        }

        [Route("api/contacts/{id}/messages")]
        [HttpPost("{id}")]
        public IActionResult AddMessage(string userID, string id , int id2, string type, string content, string own, string time, string date)
        {
            Message message = new Message(id2, type, content, own, time, date);
            if (!ModelState.IsValid)
            {
                _contactsService.AddMessage(userID, id, message);
                return NoContent();
            }
            return BadRequest();
        }

    }
}
