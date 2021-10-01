using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.ViewModels.Identity
{
    public class LoginFormModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Token { get; set; }
    }
}
