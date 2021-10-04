using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Casino.Common.Infrastructure;
using Casino.Common.Services;
using Casino.Slot.Data;
using Casino.Slot.Models.Symbols;
using Casino.Slot.Services;
using Casino.Slot.Services.Repositories;
using Casino.Slot.Services.Symbols;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Casino.Slot
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddWebService<SlotMachineDbContext>(this.Configuration)
                .AddTransient<IDataSeeder, SlotMachineDataSeeder>()
                .AddTransient<ISlotMachineService, SlotMachineService>()
                .AddTransient<ISymbolGenerationService, SymbolGenerationService>()
                .AddTransient<ISymbolRepository, SymbolRepository>()
                .AddTransient<ISpinResultRepository, SpinResultRepository>()
                .AddMessaging(this.Configuration);

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .Initialize();
    }
}
