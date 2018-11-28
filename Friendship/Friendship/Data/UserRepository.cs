using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Friendship.Models;
using Microsoft.Extensions.Configuration;

namespace Friendship.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly FriendshipContext _context;
        private readonly IConfiguration config;

        public UserRepository(FriendshipContext context, IConfiguration iconfig)
        {
            _context = context;
            config = iconfig;
        }

        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public async  Task<User> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAll()
        {
            int changes = _context.SaveChanges();
            if (changes > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
