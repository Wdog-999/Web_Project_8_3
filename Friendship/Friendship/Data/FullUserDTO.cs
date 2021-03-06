﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friendship.Data
{
    public class FullUserDTO
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string PhotoUrl { get; set; }
    }
}