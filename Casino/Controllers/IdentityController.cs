using AutoMapper;
using Casino.Common.Infrastructure;
using Casino.Services.Identity;
using Casino.ViewModels.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Casino.Common.Infrastructure.InfrastructureConstants;

namespace Casino.Controllers
{
    public class IdentityController : AdministrationController
    {
        private readonly IIdentityService identityService;
        private readonly IMapper mapper;

        public IdentityController(
            IIdentityService identityService,
            IMapper mapper)
        {
            this.identityService = identityService;
            this.mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginFormModel model)
            => await this.Handle(
                async () =>
                {
                    var result = await this.identityService
                        .Login(this.mapper.Map<UserInputModel>(model));

                    this.Response.Cookies.Append(
                        AuthenticationCookieName,
                        result.Token,
                        new CookieOptions
                        {
                            HttpOnly = true,
                            Secure = false,
                            MaxAge = TimeSpan.FromDays(1)
                        });
                },
                success: RedirectToAction(nameof(HomeController.Homepage), "Home"),
                failure: View("../Home/Index", model));

        [AuthorizeAdministrator]
        public IActionResult Logout()
        {
            this.Response.Cookies.Delete(AuthenticationCookieName);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
