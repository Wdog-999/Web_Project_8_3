using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Friendship.Data;
using Friendship.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AutoMapper;

namespace Friendship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Add<T>(T entity) where T : class
        {
            _repo.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _repo.Delete(entity);
        }

        [HttpGet("getuser")]
        public async Task<User> GetUser(string id)
        {
            var user = await _repo.GetUser(id);
            //var userDetails = _mapper.Map<FullUserDTO>(user);
            return user;
        }

        [HttpGet("getusers")]
        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _repo.GetUsers();
            return users;
        }

        [HttpGet("saveall")]
        public async Task<bool> SaveAll()
        {
            return await _repo.SaveAll();
        }
    }
}