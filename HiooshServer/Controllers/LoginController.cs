using Microsoft.AspNetCore.Mvc;
using HiooshServer.Services;
using HiooshServer.Models;

namespace HiooshServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IContactsService _contactsService;
        public LoginController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }
        [HttpPost("{id}")]
        public IActionResult Login(string id)
        {
            HttpContext.Session.SetString("username", id);
            return Created(string.Format("/api/login", id), id);
            
        }
    }
}
