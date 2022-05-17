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
            if (!ModelState.IsValid)
            {
                //HttpContext.Session.SetString("userid", id);
                return Created(string.Format("/api/login", id), id);
            }
            return BadRequest();
        }
    }
}
