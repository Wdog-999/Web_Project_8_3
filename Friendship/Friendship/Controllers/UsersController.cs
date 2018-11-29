using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Friendship.Data;
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
        private readonly UserRepository _repo;

        public UsersController(UserRepository repo)
        {
            _repo = repo;
        }

        public void Add<T>(T entity) where T : class
        {
            _repo.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _repo.Delete(entity);
        }

        public async Task<User> GetUser(string id)
        {
            return await _repo.GetUser(id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _repo.GetUsers();
        }

        public async Task<bool> SaveAll()
        {
            return await _repo.SaveAll();
        }
    }
}