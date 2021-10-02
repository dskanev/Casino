using Casino.Common.Services;
using Casino.UserHistory.Data.Models;
using Casino.UserHistory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.UserHistory.Services
{
    public interface ISpinHistoryRepository : IDataService<SpinHistory>
    {
        Task<List<SpinHistory>> GetSpinHistory(string userId);
        Task SaveSpinHistoryRecord(HistoryRecordInputModel model);
    }
}
