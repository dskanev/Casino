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

        private static string InsufficientFundsError = "Insufficient funds.";
        private static string UserDataNotFoundError = "No balance data was found for this user.";

        public UserHistoryService(IUserBalanceRepository userBalanceRepository,
            ISpinHistoryRepository spinHistoryRepository,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.spinHistoryRepository = spinHistoryRepository;
            this.userBalanceRepository = userBalanceRepository;
        }

        public async Task<List<SpinHistory>> GetSpinHistory(string userId)
        {
            return await spinHistoryRepository
                .GetSpinHistory(userId);
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
            await userBalanceRepository.Save(userBalance);

            return new UserOutputModel(userBalance.Balance);
        }

        public async Task<Result<UserOutputModel>> GetBalance(string userId)
        {
            var userBalance = await userBalanceRepository.GetUserBalanceAsync(userId);

            if (userBalance == default)
            {
                return UserDataNotFoundError;
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
