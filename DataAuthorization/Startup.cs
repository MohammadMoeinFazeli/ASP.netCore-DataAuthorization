using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAuthorization.Config;
using DataAuthorization.Config.Extentions;
using DataAuthorization.DataBase;
using DataAuthorization.DataBase.Extentions;
using DataAuthorization.Services.UserService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DataAuthorization
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // configure strongly typed settings objects
            var appSettingsSection = _configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();

            // configure Dbcontext service
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(appSettings.DbConnection)
            );

            // configure jwt authentication
            services.AddOurAuthentication(appSettings);
            services.AddOurSwaager();

            // DI services
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IGetClaimsProvider, GetClaimsFromUser>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRequestService, RequestService>();


            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}
