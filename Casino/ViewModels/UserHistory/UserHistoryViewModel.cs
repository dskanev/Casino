using Casino.ViewModels.SlotMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.ViewModels.UserHistory
{
    public class UserHistoryViewModel
    {
        public IEnumerable<SpinHistory> PastSpins { get; set; }
        public SpinHistory BiggestWin { get; set; }
        public double Balance { get; set; }

        public UserHistoryViewModel()
        {
            this.PastSpins = new List<SpinHistory>();
        }
    }
}
