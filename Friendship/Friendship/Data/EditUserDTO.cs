using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friendship.Data
{
    public class EditUserDTO
    {
        public string Name { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
    }
}