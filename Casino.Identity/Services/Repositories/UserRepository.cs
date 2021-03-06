using AutoMapper;
using Casino.Common.Services;
using Casino.Identity.Data;
using Casino.Identity.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Identity.Services
{
    public class UserRepository : DataService<User>, IUserRepository
    {
        private readonly IMapper mapper;

        public UserRepository(IdentityDbContext db, IMapper mapper)
        : base(db)
            => this.mapper = mapper;
    }


}
