using Casino.Common.Services;
using Casino.Identity.Data.Models;
using Casino.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Identity.Services
{
    public interface IIdentityService
    {
        Task<Result<User>> Register(UserInputModel userInput);
        Task<Result<UserOutputModel>> Login(UserInputModel userInput);
        Task<Result> ChangePassword(string userId, ChangePasswordInputModel changePasswordInput);
    }
}
