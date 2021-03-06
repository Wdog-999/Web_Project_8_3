﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Friendship.Models;
using Microsoft.EntityFrameworkCore;
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

        public async  Task<User> GetUser(string id)
        {
            if (id == null)
            {
                return null;
            }

            var user = await _context.Users.Include(p => p.Photos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return null;
            }
            //IQueryable<Photo> photoQuery = from p in _context.Photos
            //                                 select p;
            //var photos = photoQuery;
            //user.Photos = photos.Where(s => s.UserId == user.Id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = from u in _context.Users.Include(p => p.Photos)
                        select u;
            return users;
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
