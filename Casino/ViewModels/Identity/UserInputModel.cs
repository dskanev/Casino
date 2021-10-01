using Casino.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.ViewModels.Identity
{
    public class UserInputModel : IMapFrom<LoginFormModel>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
