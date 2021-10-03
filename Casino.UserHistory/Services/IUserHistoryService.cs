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
        /// <summary>
        /// Gets the last spins for a user in a descending chronological order.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="limit">limits the result by a number</param>
        /// <returns></returns>
        Task<List<SpinHistory>> GetSpinHistory(string userId, int limit);
        /// <summary>
        /// Retrieves the biggest with from a user's history.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<SpinHistory> GetBiggestWin(string userId);
        /// <summary>
        /// Saves a history record of a user's spin.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task SaveSpinHistoryRecord(HistoryRecordInputModel model);
        /// <summary>
        /// Adds a number to a user's balance.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="balanceToAdd">can be either a positive or a negative number</param>
        /// <returns></returns>
        Task<Result<UserOutputModel>> AddBalance(string userId, double balanceToAdd);
        /// <summary>
        /// Gets the balance associated with a specific user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<Result<UserOutputModel>> GetBalance(string userId);
        /// <summary>
        /// Sets the user balance to a specific value
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="newBalance"></param>
        /// <returns></returns>
        Task<Result<UserOutputModel>> UpdateBalance(string userId, double newBalance);
    }
}
