using AutoMapper;
using Casino.Common.Models;
using Casino.Common.Services;
using Casino.UserHistory.Data;
using Casino.UserHistory.Data.Models;
using Casino.UserHistory.Data.Repositories;
using Casino.UserHistory.Models;
using Casino.UserHistory.Models.UserDetails;
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
        private readonly IUserDetailsRepository userDetailsRepository;
        private readonly IAddressRepository addressRepository;

        private static string UserDataNotFoundError = "No balance data was found for this user.";
        private static string CannotHaveNegativeBalanceError = "Negative balance is not possible.";

        public UserHistoryService(IUserBalanceRepository userBalanceRepository,
            ISpinHistoryRepository spinHistoryRepository,
            IUserDetailsRepository userDetailsRepository,
            IAddressRepository addressRepository,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.spinHistoryRepository = spinHistoryRepository;
            this.userBalanceRepository = userBalanceRepository;
            this.userDetailsRepository = userDetailsRepository;
            this.addressRepository = addressRepository;
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

        public async Task<Result<UserDetailsInputModel>> SaveUserDetails(UserDetailsInputModel details)
        {
            var address = mapper.Map<Address>(details);
            await addressRepository.Save(address);

            var userDetails = mapper.Map<UserDetails>(details);
            userDetails.Address = address;
            
            await userDetailsRepository.Save(userDetails);

            return Result<UserDetailsInputModel>.SuccessWith(details);
        }

        public async Task<Result<UserDetails>> GetUserDetails(string userId)
        {
            var result = await userDetailsRepository.GetUserDetails(userId);
            return Result<UserDetails>.SuccessWith(result.Data);
        }
    }
}
