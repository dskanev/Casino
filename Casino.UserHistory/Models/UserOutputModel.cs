using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.UserHistory.Models
{
    public class UserOutputModel
    {
        public UserOutputModel(double balance)
        {
            Balance = balance;
        }

        public double Balance { get; }
    }
}
