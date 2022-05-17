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
        public IActionResult Create(string userID, string id, string name, string server)
        {
          if (!ModelState.IsValid)
            {
                Contact contact = new Contact(id, name, server);
                _contactsService.AddContact(userID, contact);
                return Created(string.Format("/api/contacts/{0}", contact.id), contact);
            }
           return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string userID, string id, string nickname, string server)
        {
            if (ModelState.IsValid)
            {
                _contactsService.UpdateContact(userID, id, nickname, server);
                return NoContent();

            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string userID, string id)
        {
            _contactsService.RemoveContact(userID, id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult Get(string userID, string id)
        {
            Contact? contact = _contactsService.GetContact(userID, id);
            if (contact != null)
            {
                return Json(contact);
            }
            return BadRequest();
        }

        // need to check how to add the "messages" to the url
        [Route("api/contacts/{id}/messages")]
        [HttpGet("{id}")]
        public IActionResult GetMessages(string userID, string id)
        {
            Contact? contact = _contactsService.GetContact(userID, id);
            if (contact != null)
            {
                return Json(_contactsService.GetMessages(userID, id));
            }
            return BadRequest();
        }

        [Route("api/contacts/{id}/messages")]
        [HttpPost("{id}")]
        public IActionResult AddMessage(string userID, string id , int msg_id, string content, bool sent, string created)
        {
            Message message = new Message(msg_id, content, sent, created);
            if (!ModelState.IsValid)
            {
                _contactsService.AddMessage(userID, id, message);
                return NoContent();
            }
            return BadRequest();
        }

        [Route("api/contacts/{id1}/messages/{id2}")]
        [HttpGet("{id2}")]
        public IActionResult GetMessage(string userID, string id1, int id2)
        {
            Message? message = _contactsService.GetMessage(userID, id1, id2);
            if (message != null)
            {
                return Json(message);

            }
            return BadRequest();
        }

        [Route("api/contacts/{id1}/messages/{id2}")]
        [HttpPut("{id2}")]
        public IActionResult UpdateMessage(string userID, string id1, int id2, string content)
        {
            Message? message = _contactsService.GetMessage(userID, id1, id2);
            if (message != null)
            {
                _contactsService.UpdateMessage(userID, id1, id2, content);
                return NoContent();

            }
            return BadRequest();
        }

        [Route("api/contacts/{id1}/messages/{id2}")]
        [HttpDelete("{id2}")]
        public IActionResult DeleteMessage(string userID, string id1, int id2)
        {
            Message? message = _contactsService.GetMessage(userID, id1, id2);
            if (message != null)
            {
                _contactsService.RemoveMessage(userID, id1, id2);
                return NoContent();

            }
            return BadRequest();
        }
    }
}
