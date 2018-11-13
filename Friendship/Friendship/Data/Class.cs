using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friendship.Models
{
    public class FriendshipContext : IdentityDbContext<User>
    {
        public FriendshipContext(DbContextOptions<FriendshipContext> options)
            : base(options)
        {
        }
    }
}
