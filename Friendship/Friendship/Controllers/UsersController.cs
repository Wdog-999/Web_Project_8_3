using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Friendship.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Friendship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly FriendshipContext _context;
        private readonly IConfiguration config;

        public UsersController(FriendshipContext context, IConfiguration iconfig)
        {
            _context = context;
            config = iconfig;
        }



    }
}