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
    //[Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        private readonly FriendshipContext _context;

        public UsersController(IUserRepository repo, IMapper mapper, FriendshipContext context)
        {
            _repo = repo;
            _mapper = mapper;
            _context = context;
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
        public async Task<FullUserDTO> GetUser(string id)
        {
            var user = await _repo.GetUser(id);
            var userDetails = _mapper.Map<FullUserDTO>(user);
            return userDetails;
        }

        [HttpGet("getusers")]
        public async Task<IEnumerable<BriefUserDTO>> GetUsers()
        {
            var users = await _repo.GetUsers();
            var userList = _mapper.Map<IEnumerable<BriefUserDTO>>(users);
            return userList;
        }

        [HttpPut("updateuser")]
        public async void UpdateUser(string id, User changes)
        {
            var user = await _repo.GetUser(id);
            var userchanges = _mapper.Map<EditUserDTO>(changes);
            user.Interests = userchanges.Interests;
            user.Introduction = userchanges.Introduction;
            user.LookingFor = userchanges.LookingFor;
            user.Name = userchanges.Name;
            _context.Update(user);
            _context.SaveChanges();

        }

        [HttpGet("saveall")]
        public async Task<bool> SaveAll()
        {
            return await _repo.SaveAll();
        }
    }
}