using Casino.ViewModels.SlotMachine;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Services.UserHistory
{
    public interface IUserHistoryService
    {
        [Get("/History/GetSpinHistory/{userId}")]
        Task<List<SpinHistoryOutputModel>> GetSpinHistory(string userId);
    }
}
