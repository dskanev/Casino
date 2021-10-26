using Casino.Common.Data.Models;
using Casino.UserHistory.Models.UserDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.UserHistory.Data.Models
{
    public class Address : DatabaseModel
    {
        public string UserId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public long StreetNumber { get; set; }        
    }
}
