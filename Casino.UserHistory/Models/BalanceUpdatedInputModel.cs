using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.UserHistory.Models
{
    public class BalanceUpdatedInputModel
    {
        public string UserId { get; set; }
        public double Balance { get; set; }
    }
}
