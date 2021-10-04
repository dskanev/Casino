using AutoMapper;
using Casino.Common.Models;
using Casino.UserHistory.Data;
using Casino.UserHistory.Data.Models;
using Casino.UserHistory.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Casino.Test
{
    [TestClass]
    public class UserHistoryServiceTests
    {
        [TestMethod]
        public async Task AddNegativeBalanceTest()
        {
            using (var context = GetContext("AddNegativeBalanceTest"))
            {
                context.Add(new UserBalance() { UserId = "123", Balance = 100, Id = 1 });
                await context.SaveChangesAsync();

                var userBalanceRepository = new UserBalanceRepository(context, null);
                var service = new UserHistoryService(userBalanceRepository, null, null);

                await service.AddBalance("123", -10);                
            }
            using (var context = GetContext("AddNegativeBalanceTest"))
            {
                var userBalance = context.Set<UserBalance>().Where(x => x.Id == 1).FirstOrDefault();
                Assert.IsTrue(userBalance.Balance == 90);
            }
        }

        [TestMethod]
        public async Task AddPositiveBalanceTest()
        {
            using (var context = GetContext("AddPositiveBalanceTest"))
            {
                context.Add(new UserBalance() { UserId = "123", Balance = 100, Id = 1 });
                await context.SaveChangesAsync();

                var userBalanceRepository = new UserBalanceRepository(context, null);

                var service = new UserHistoryService(userBalanceRepository, null, null);
                await service.AddBalance("123", 10);
            }
            using (var context = GetContext("AddPositiveBalanceTest"))
            {
                var userBalance = context.Set<UserBalance>().Where(x => x.Id == 1).FirstOrDefault();
                Assert.IsTrue(userBalance.Balance == 110);
            }
        }

        [TestMethod]
        public async Task DropBalanceBelowZero()
        {
            using (var context = GetContext("DropBalanceBelowZero"))
            {
                context.Add(new UserBalance() { UserId = "123", Balance = 100, Id = 1 });
                await context.SaveChangesAsync();

                var userBalanceRepository = new UserBalanceRepository(context, null);

                var service = new UserHistoryService(userBalanceRepository, null, null);
                await service.AddBalance("123", -110);
            }
            using (var context = GetContext("DropBalanceBelowZero"))
            {
                var userBalance = context.Set<UserBalance>().Where(x => x.Id == 1).FirstOrDefault();
                Assert.IsTrue(userBalance.Balance >= 0);
            }
        }

        private static UserHistoryDbContext GetContext(string name)
        {
            var dbOptions = new DbContextOptionsBuilder<UserHistoryDbContext>()
                .UseInMemoryDatabase(name).Options;

            return new UserHistoryDbContext(dbOptions);
        }
    }
}
