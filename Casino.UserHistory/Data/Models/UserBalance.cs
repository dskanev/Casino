using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.UserHistory.Data.Models
{
    public class UserBalance
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public double Balance { get; set; }
    }
}
