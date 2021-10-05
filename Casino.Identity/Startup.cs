using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Casino.Common.Infrastructure;
using Casino.Common.Services;
using Casino.Identity.Data;
using Casino.Identity.Infrastructure;
using Casino.Identity.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Casino.Identity
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
               .AddWebService<IdentityDbContext>(this.Configuration)
               .AddUserStorage()
               .AddTransient<IDataSeeder, IdentityDataSeeder>()
               .AddTransient<IIdentityService, IdentityService>()
               .AddTransient<ITokenGeneratorService, TokenGeneratorService>()
               .AddTransient<IUserRepository, UserRepository>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .Initialize();
    }
}
