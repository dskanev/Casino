using Casino.ViewModels.Identity;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Services.Identity
{
    public interface IIdentityService
    {
        [Post("/Identity/Login")]
        Task<UserOutputModel> Login([Body] UserInputModel loginInput);
    }
}
