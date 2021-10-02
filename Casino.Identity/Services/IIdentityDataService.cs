using Casino.Common.Services;
using Casino.Identity.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Identity.Services
{
    public interface IIdentityDataService : IDataService<User>
    {
    }
}
