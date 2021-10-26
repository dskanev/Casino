using AutoMapper;
using Casino.Common.Services;
using Casino.UserHistory.Data.Models;
using Casino.UserHistory.Models.UserDetails;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.UserHistory.Data.Repositories
{
    public class UserDetailsRepository : DataService<UserDetails>, IUserDetailsRepository
    {
        private readonly IMapper mapper;

        public UserDetailsRepository(UserHistoryDbContext db, IMapper mapper)
        : base(db)
        {
            this.mapper = mapper;
        }

        public async Task<Result<UserDetails>> GetUserDetails(string userId)
        {
            var result = await this
                .All()
                .Where(x => x.UserId == userId)
                .Include(x => x.Address)
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
