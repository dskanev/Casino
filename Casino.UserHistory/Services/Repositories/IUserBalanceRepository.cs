using Casino.Common.Services;
using Casino.UserHistory.Data.Models;
using Casino.UserHistory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.UserHistory.Services
{
    public interface IUserBalanceRepository : IDataService<UserBalance>
    {
        Task<UserBalance> GetUserBalanceAsync(string userId);
    }
}
