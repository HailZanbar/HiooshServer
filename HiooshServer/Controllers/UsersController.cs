using HiooshServer.Models;
using HiooshServer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HiooshServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IContactsService _contactsService;

        public UsersController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }
        public IActionResult GetUsers()
        {
            return Json(_contactsService.GetUsers());
        }

        [HttpPost]
        public IActionResult Create([FromBody] JsonElement fields)
        {
            if (_contactsService.GetUser(fields.GetProperty("userid").ToString()) != null)
            {
                // get the fields from the body request
                string id = fields.GetProperty("id").ToString();
                string nickname = fields.GetProperty("nickname").ToString();
                string image = fields.GetProperty("image").ToString();
                string password = fields.GetProperty("password").ToString();

                User user = new User(id, password, nickname, image);
                _contactsService.AddUser(user);
                return Created(string.Format("/api/users/", user), user);
            }
            // need to take care to return view that user is not login
            return BadRequest();
        }
    }
}
