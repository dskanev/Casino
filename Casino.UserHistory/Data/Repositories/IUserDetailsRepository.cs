using Casino.Common.Services;
using Casino.UserHistory.Data.Models;
using Casino.UserHistory.Models.UserDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.UserHistory.Data.Repositories
{
    public interface IUserDetailsRepository : IDataService<UserDetails>
    {
        Task<Result<UserDetails>> GetUserDetails(string userId);
    }
}
