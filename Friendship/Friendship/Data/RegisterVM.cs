using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friendship.Data
{
    public class RegisterVM
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public DateTime BirthDate { get; set; }
    }
}