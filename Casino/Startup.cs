using Casino.Common.Infrastructure;
using Casino.Common.Services.Identity;
using Casino.Infrastructure;
using Casino.Services;
using Casino.Services.Identity;
using Casino.Services.Slot;
using Casino.Services.UserHistory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Casino
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var serviceEndpoints = this.Configuration
                .GetSection(nameof(ServiceEndpoints))
                .Get<ServiceEndpoints>(config => config.BindNonPublicProperties = true);

            services
                .AddAutoMapperProfile(Assembly.GetExecutingAssembly())
                .AddTokenAuthentication(this.Configuration)
                .AddScoped<ICurrentTokenService, CurrentTokenService>()
                .AddTransient<JwtCookieAuthenticationMiddleware>()
                .AddControllersWithViews(options => options
                    .Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));

            services
                .AddRefitClient<IIdentityService>()
                .WithConfiguration(serviceEndpoints.Identity);

            services
                .AddRefitClient<ISlotService>()
                .WithConfiguration(serviceEndpoints.Slot);

            services
                .AddRefitClient<IUserHistoryService>()
                .WithConfiguration(serviceEndpoints.UserHistory);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app
                    .UseDeveloperExceptionPage();
            }
            else
            {
                app
                    .UseExceptionHandler("/Home/Error")
                    .UseHsts();
            }

            app
                .UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseJwtCookieAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints
                    .MapDefaultControllerRoute());
        }
    }
}
