using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Identity.Data.Models
{
    public class User : IdentityUser
    {
        public double Balance { get; set; }
    }
}
