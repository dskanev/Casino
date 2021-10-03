using Casino.Common.Services;
using Casino.UserHistory.Data.Models;
using Casino.UserHistory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.UserHistory.Services
{
    public interface IUserHistoryService
    {
        Task<List<SpinHistory>> GetSpinHistory(string userId, int limit);
        Task<SpinHistory> GetBiggestWin(string userId);
        Task SaveSpinHistoryRecord(HistoryRecordInputModel model);
        Task<Result<UserOutputModel>> AddBalance(string userId, double balanceToAdd);
        Task<Result<UserOutputModel>> GetBalance(string userId);
        Task<Result<UserOutputModel>> UpdateBalance(string userId, double newBalance);
    }
}
