using AutoMapper;
using Casino.Common.Services;
using Casino.Slot.Data;
using Casino.Slot.Models.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Slot.Services
{
    public class SlotMachineDataService : DataService<Symbol>, ISlotMachineDataService
    { 
        private readonly IMapper mapper;

        public SlotMachineDataService(SlotMachineDbContext db, IMapper mapper)
        : base(db)
            => this.mapper = mapper;

        /// <summary>
        /// Gets all symbols
        /// </summary>
        /// <returns></returns>
        public List<Symbol> GetAllSymbols()
        {
            return this
                .All()
                .ToList();
        }
    }
}
