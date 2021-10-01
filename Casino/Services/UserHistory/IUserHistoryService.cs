using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Services.UserHistory
{
    public interface IUserHistoryService
    {
        [Get("/History/{id}")]
        Task<int> GetSpinHistory(string userId);
    }
}
