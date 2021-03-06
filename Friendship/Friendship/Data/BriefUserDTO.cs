﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friendship.Data
{
    public class BriefUserDTO
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string City { get; set; }
        public string PhotoUrl { get; set; }
    }
}