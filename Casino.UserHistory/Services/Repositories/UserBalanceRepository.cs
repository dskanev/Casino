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
    public class UserBalanceRepository : DataService<UserBalance>, IUserBalanceRepository
    {
        private readonly IMapper mapper;

        public UserBalanceRepository(UserHistoryDbContext db, IMapper mapper)
        : base(db)
        {
            this.mapper = mapper;
        }

        public async Task<UserBalance> GetUserBalanceAsync(string userId)
        {
            return await this.Data.Set<UserBalance>()
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync();
        }
    }
}
