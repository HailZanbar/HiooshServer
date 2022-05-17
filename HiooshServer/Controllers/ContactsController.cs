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
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                // need to take care to return view that user is not login
                return BadRequest();
            }
            return Json(_contactsService.GetAllContacts(HttpContext.Session.GetString("username")));
        }

        [HttpPost]
        public IActionResult Create(string id, string name, string server)
        {
          if (HttpContext.Session.GetString("username") != null)
            {
                Contact contact = new Contact(id, name, server);
                _contactsService.AddContact(HttpContext.Session.GetString("username"), contact);
                return Created(string.Format("/api/contacts/{0}", contact.id), contact);
            }
            // need to take care to return view that user is not login
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, string nickname, string server)
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                _contactsService.UpdateContact(HttpContext.Session.GetString("username"), id, nickname, server);
                return NoContent();

            }
            // need to take care to return view that user is not login
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                _contactsService.RemoveContact(HttpContext.Session.GetString("username"), id);
                return NoContent();
            }
            // if not login
            return BadRequest();
        }

        [HttpGet("{id}")]
        public IActionResult Get(string userID, string id)
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                Contact? contact = _contactsService.GetContact(HttpContext.Session.GetString("username"), id);
                if (contact != null)
                {
                    return Json(contact);
                }
            }
            // need to take care the view if not login
            return BadRequest();
        }

        // need to check how to add the "messages" to the url
        [Route("api/contacts/{id}/messages")]
        [HttpGet("{id}")]
        public IActionResult GetMessages(string id)
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                Contact? contact = _contactsService.GetContact(HttpContext.Session.GetString("username"), id);
                if (contact != null)
                {
                    return Json(_contactsService.GetMessages(HttpContext.Session.GetString("username"), id));
                }
            }
            // need to take care the part of view if not login
            return BadRequest();
        }

        [Route("api/contacts/{id}/messages")]
        [HttpPost("{id}")]
        public IActionResult AddMessage(string id , int msg_id, string content, bool sent, string created)
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                List<Message> messages = _contactsService.GetMessages(HttpContext.Session.GetString("username"), id);
                int id_of_last = messages[messages.Count - 1].id;
                Message message = new Message(id_of_last++, content, true, DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                _contactsService.AddMessage(HttpContext.Session.GetString("username"), id, message);
                return NoContent();
            }
            // need to take care if is not 
            return BadRequest();
        }

        [Route("api/contacts/{id1}/messages/{id2}")]
        [HttpGet("{id2}")]
        public IActionResult GetMessage(string id1, int id2)
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                Message? message = _contactsService.GetMessage(HttpContext.Session.GetString("username"), id1, id2);
                if (message != null)
                {
                    return Json(message);

                }
            }
            return BadRequest();
        }

        [Route("api/contacts/{id1}/messages/{id2}")]
        [HttpPut("{id2}")]
        public IActionResult UpdateMessage(string id1, int id2, string content)
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                Message? message = _contactsService.GetMessage(HttpContext.Session.GetString("username"), id1, id2);
                if (message != null)
                {
                    _contactsService.UpdateMessage(HttpContext.Session.GetString("username"), id1, id2, content);
                    return NoContent();

                }
            }
            // need to take care of the view if not login
            return BadRequest();
        }

        [Route("api/contacts/{id1}/messages/{id2}")]
        [HttpDelete("{id2}")]
        public IActionResult DeleteMessage(string userID, string id1, int id2)
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                Message? message = _contactsService.GetMessage(HttpContext.Session.GetString("username"), id1, id2);
                if (message != null)
                {
                    _contactsService.RemoveMessage(HttpContext.Session.GetString("username"), id1, id2);
                    return NoContent();

                }
            }
            return BadRequest();
        }
    }
}
