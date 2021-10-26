using AutoMapper;
using Casino.Common.Services;
using Casino.UserHistory.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.UserHistory.Data.Repositories
{
    public class AddressRepository : DataService<Address>, IAddressRepository
    {
        private readonly IMapper mapper;

        public AddressRepository(UserHistoryDbContext db, IMapper mapper)
        : base(db)
        {
            this.mapper = mapper;
        }
    }
}
