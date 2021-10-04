using Casino.Common.Services;
using Casino.Slot.Data;
using Casino.Slot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Slot.Services.Repositories
{
    public class SpinResultRepository : DataService<SpinResult>, ISpinResultRepository
    {
        public SpinResultRepository(SlotMachineDbContext db)
        : base(db)
        { }
    }
}
