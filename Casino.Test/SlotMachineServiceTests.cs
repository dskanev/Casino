using AutoMapper;
using Casino.Common.Models;
using Casino.Slot.Data;
using Casino.Slot.Services;
using Casino.Slot.Services.Symbols;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Test
{
    [TestClass]
    public class SlotMachineServiceTests
    {
        [TestMethod]
        public async Task BetNegativeAmount()
        {
            using (var context = GetContext("BetNegativeAmount"))
            {
                var slotDataService = new SymbolRepository(context);
                var symbolGenerationService = new SymbolGenerationService(slotDataService);
                var slotMachineService = new SlotMachineService(symbolGenerationService, null, null);

                var result = await slotMachineService.SpinTheSlot("123", -100);
                Assert.IsFalse(result.Succeeded);
            }
        }

        private static SlotMachineDbContext GetContext(string name)
        {
            var dbOptions = new DbContextOptionsBuilder<SlotMachineDbContext>()
                .UseInMemoryDatabase(name).Options;

            return new SlotMachineDbContext(dbOptions);
        }
    }
}
