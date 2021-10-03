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
                new Symbol{ Name  = "Apple", Coefficient = 0.4, Rarity = 0.45, ImageURL = "https://media.istockphoto.com/vectors/apple-flat-style-vector-icon-vector-id1251493047?k=20&m=1251493047&s=612x612&w=0&h=6ifRKhn4FkuIP_djq2sLUq2HInNjy_bU4ejg4D83oCM=" },
                new Symbol{ Name = "Banana", Coefficient = 0.6, Rarity = 0.35, ImageURL = "https://globalsymbols.com/uploads/production/image/imagefile/3225/13_3225_79654013-263a-426a-a731-55deccb2871c.svg" },
                new Symbol{ Name = "Pineapple", Coefficient = 0.8, Rarity = 0.15, ImageURL = "https://www.eyespyinvestigations.com/wp-content/uploads/nicubunu-Pineapple-253x300-253x300.png" },
                new Symbol{ Name = "Wildcard", Coefficient = 0, Rarity = 0.05, ImageURL = "https://www.pinclipart.com/picdir/middle/228-2282109_10-symbol-wild-jh-thumbnail-clipart.png" },
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
