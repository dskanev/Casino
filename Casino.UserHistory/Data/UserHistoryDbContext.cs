using Casino.Common.Data;
using Casino.UserHistory.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Casino.UserHistory.Data
{
    public class UserHistoryDbContext : MessageDbContext
    {
        public UserHistoryDbContext(DbContextOptions<UserHistoryDbContext> options)
            : base(options)
        {
        }

        public DbSet<SpinHistory> SpinHistory { get; set; }
        public DbSet<UserBalance> UserBalance { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override Assembly ConfigurationsAssembly => Assembly.GetExecutingAssembly();
    }
}
