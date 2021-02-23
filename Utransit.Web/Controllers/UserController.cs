using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utransit.Services.Contracts;
using UTransit.Models;
using UTransit.Models.Requests;

namespace Utransit.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost,Route("Login")]
        public IActionResult Login([FromBody]LoginRequest request)
        {
            var result = _userService.Login(request);
            if (result.IsSucessful) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost, Route("AddUsers")]
        public IActionResult AddUsers([FromBody] IList<User> request)
        {
            var result = _userService.AddUsers(request);
            if (result.IsSucessful) return Ok(result);
            return BadRequest(result);
        }
    }
}
