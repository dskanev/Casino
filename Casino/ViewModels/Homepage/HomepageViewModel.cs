using Casino.ViewModels.SlotMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.ViewModels.Homepage
{
    public class HomepageViewModel
    {
        public IEnumerable<SpinHistoryOutputModel> PastSpins { get; set; } = new List<SpinHistoryOutputModel>();
    }
}
