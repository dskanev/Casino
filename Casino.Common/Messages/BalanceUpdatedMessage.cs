using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Common.Messages
{
    public class BalanceUpdatedMessage
    {
        public string UserId { get; set; }
        public double AddBalance { get; set; }
    }
}
