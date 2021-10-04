using Casino.Common.Data;
using Casino.Slot.Models;
using Casino.Slot.Models.Symbols;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Casino.Slot.Data
{
    public class SlotMachineDbContext : MessageDbContext
    {
        public SlotMachineDbContext(DbContextOptions<SlotMachineDbContext> options)
            : base(options)
        {
        }

        public DbSet<Symbol> Symbols { get; set; }
        public DbSet<SpinResult> SpinResults { get; set; }

        protected override Assembly ConfigurationsAssembly => Assembly.GetExecutingAssembly();
    }
}
