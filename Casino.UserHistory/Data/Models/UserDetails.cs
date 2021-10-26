﻿using Casino.Common.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.UserHistory.Data.Models
{
    public class UserDetails : DatabaseModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalEmail { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
    }
}
