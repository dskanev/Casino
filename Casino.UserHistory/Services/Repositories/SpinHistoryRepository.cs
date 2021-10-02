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
    public class SpinHistoryRepository : DataService<SpinHistory>, ISpinHistoryRepository
    {
        private readonly IMapper mapper;

        public SpinHistoryRepository(UserHistoryDbContext db, IMapper mapper)
        : base(db)
        {
            this.mapper = mapper;
        }

        public async Task<List<SpinHistory>> GetSpinHistory(string userId)
        {
            return await this
                .All()
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task SaveSpinHistoryRecord(HistoryRecordInputModel model)
        {
            await this
                .Save(new SpinHistory
                {
                    UserId = model.UserId,
                    Won = model.Won,
                    Winnings = model.Winnings,
                    BetAmmount = model.BetAmount,
                    Timestamp = model.Timestamp
                });
        }
    }
}
