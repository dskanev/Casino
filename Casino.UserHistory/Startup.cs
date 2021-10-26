using Casino.Common.Infrastructure;
using Casino.UserHistory.Data;
using Casino.UserHistory.Data.Repositories;
using Casino.UserHistory.Messages;
using Casino.UserHistory.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.UserHistory
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                  .AddWebService<UserHistoryDbContext>(this.Configuration)
                  .AddTransient<IUserHistoryService, UserHistoryService>()
                  .AddTransient<IUserBalanceRepository, UserBalanceRepository>()
                  .AddTransient<ISpinHistoryRepository, SpinHistoryRepository>()
                  .AddTransient<IAddressRepository, AddressRepository>()
                  .AddTransient<IUserDetailsRepository, UserDetailsRepository>()
                  .AddMessaging(this.Configuration, typeof(SlotMachineWasSpunConsumer), typeof(BalanceUpdatedConsumer));

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .Initialize();
    }
}
