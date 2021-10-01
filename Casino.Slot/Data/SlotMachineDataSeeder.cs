using Casino.Common.Services;
using Casino.Slot.Models.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Slot.Data
{
    public class SlotMachineDataSeeder : IDataSeeder
    {
        private static IEnumerable<Symbol> GetData()
            => new List<Symbol>
            {
                new Symbol{ Name  = "Apple", Coefficient = 0.4, Rarity = 0.45 },
                new Symbol{ Name = "Banana", Coefficient = 0.6, Rarity = 0.35 },
                new Symbol{ Name = "Pineapple", Coefficient = 0.8, Rarity = 0.15 },
                new Symbol{ Name = "Wildcard", Coefficient = 0, Rarity = 0.05 },
            };

        private readonly SlotMachineDbContext db;

        public SlotMachineDataSeeder(SlotMachineDbContext db) => this.db = db;

        public void SeedData()
        {
            if (this.db.Symbols.Any())
            {
                return;
            }

            foreach (var symbol in GetData())
            {
                this.db.Symbols.Add(symbol);
            }

            this.db.SaveChanges();
        }
    }
}
