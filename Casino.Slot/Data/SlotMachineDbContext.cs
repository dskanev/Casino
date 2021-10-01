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
    public class SlotMachineDbContext : DbContext
    {
        public SlotMachineDbContext(DbContextOptions<SlotMachineDbContext> options)
            : base(options)
        {
        }

        public DbSet<Symbol> Symbols { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
