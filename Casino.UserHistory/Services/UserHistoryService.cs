using AutoMapper;
using Casino.Common.Services;
using Casino.UserHistory.Data;
using Casino.UserHistory.Data.Models;
using Casino.UserHistory.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.UserHistory.Services
{
    public class UserHistoryService : IUserHistoryService
    {
        private readonly IMapper mapper;
        private readonly ISpinHistoryRepository spinHistoryRepository;
        private readonly IUserBalanceRepository userBalanceRepository;

        private static string UserDataNotFoundError = "No balance data was found for this user.";
        private static string CannotHaveNegativeBalanceError = "Negative balance is not possible.";

        public UserHistoryService(IUserBalanceRepository userBalanceRepository,
            ISpinHistoryRepository spinHistoryRepository,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.spinHistoryRepository = spinHistoryRepository;
            this.userBalanceRepository = userBalanceRepository;
        }

        public async Task<List<SpinHistory>> GetSpinHistory(string userId, int limit)
        {
            return await spinHistoryRepository
                .GetSpinHistory(userId, limit);
        }

        public async Task<SpinHistory> GetBiggestWin(string userId)
        {
            return await spinHistoryRepository
                .GetBiggestWin(userId);
        }

        public async Task SaveSpinHistoryRecord(HistoryRecordInputModel model)
        {
            await spinHistoryRepository
                .SaveSpinHistoryRecord(model);
        }

        public async Task<Result<UserOutputModel>> AddBalance(string userId, double balanceToAdd)
        {
            var userBalance = await userBalanceRepository.GetUserBalanceAsync(userId);

            if (userBalance == default)
            {
                return UserDataNotFoundError;
            }

            userBalance.Balance += balanceToAdd;

            if (userBalance.Balance < 0)
            {
                return CannotHaveNegativeBalanceError;
            }

            await userBalanceRepository.Save(userBalance);

            return new UserOutputModel(userBalance.Balance);
        }

        public async Task<Result<UserOutputModel>> GetBalance(string userId)
        {
            var userBalance = await userBalanceRepository.GetUserBalanceAsync(userId);

            if (userBalance == default)
            {
                userBalance = new UserBalance { UserId = userId, Balance = 100 };
                await userBalanceRepository.Save(userBalance);
            }

            return new UserOutputModel(userBalance.Balance);
        }

        public async Task<Result<UserOutputModel>> UpdateBalance(string userId, double newBalance)
        {
            var userBalance = await userBalanceRepository.GetUserBalanceAsync(userId);

            if (userBalance == default)
            {
                return UserDataNotFoundError;
            }

            userBalance.Balance = newBalance;
            await userBalanceRepository.Save(userBalance);

            return new UserOutputModel(userBalance.Balance);
        }
    }
}
