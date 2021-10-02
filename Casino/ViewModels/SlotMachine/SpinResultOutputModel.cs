using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.ViewModels.SlotMachine
{
    public class SpinResultOutputModel
    {
        public Spin SpinResult { get; set; }
        public double  NewBalance { get; set; }
    }
}
