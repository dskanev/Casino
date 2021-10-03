using Casino.ViewModels.SlotMachine;
using Casino.ViewModels.UserHistory;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Services.UserHistory
{
    public interface IUserHistoryService
    {
        [Get("/History/GetSpinHistory/{userId}/{limit}")]
        Task<List<SpinHistory>> GetSpinHistory(string userId, int limit);

        [Get("/History/GetBiggestWin/{userId}")]
        Task<SpinHistory> GetBiggestWin(string userId);

        [Get("/History/GetBalance/{userId}")]
        Task<BalanceOutputModel> GetBalance(string userId);

        [Post("/History/AddBalance/{userId}/{balance}")]
        Task<BalanceOutputModel> AddBalance(string userId, double balance);

        [Post("/History/UpdateBalance/{userId}/{newBalance}")]
        Task <BalanceOutputModel> UpdateBalance(string userId, double newBalance);
    }
}
