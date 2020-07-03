using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet("{id}")]
        public User Get (int id)
        {
            return new User
            {
                UserId = id,
                Email = "catalin@webbeds.com",
                UserName = "catallin"
            };
        }
    }
}
