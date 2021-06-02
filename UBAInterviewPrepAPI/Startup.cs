using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.SQLite;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UBAInterviewPrepAPI.DAL.Data.Context;
using UBAInterviewPrepAPI.DAL.Data.Repositories;
using UBAInterviewPrepAPI.DAL.Data.UOW;
using UBAInterviewPrepAPI.Domain.Models.Auth;
using UBAInterviewPrepAPI.Domain.Models.ConfigModels;
using UBAInterviewPrepAPI.Extensions;
using UBAInterviewPrepAPI.Services.DigitalTravels;

namespace UBAInterviewPrepAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //var jwtSettings = Configuration.GetSection("Jwt").Get<JwtSettings>();
            services.AddDbContext<MyDataContext>(options => options.UseSqlite(Configuration.GetConnectionString("SQLiteDBConn")));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));
            //configure AmadeusSettings using AppSecrets ...
            var amadeusApiConfig = new AmadeusSettings({
                BaseUrl = Configuration["AmadeusSettings:BaseUrl"],
                GrantType = Configuration["AmadeusSettings:GrantType"],
                ClientId = Configuration["AmadeusSettings:ClientId"],
                ClientSecret = Configuration["AmadeusSettings:ClientSecret"]
                });
            var jwtSettings = new JwtSettings({
                Issuer = Configuration["JwtSettings:Issuer"],
                Secret = Configuration["JwtSettings:Secret"],
                ExpirationInDays = Configuration["JwtSettings:ExpirationInDays"]
                });
            services.AddSingleton<AmadeusSettings>(amadeusApiConfig);
            services.AddSingleton<JwtSettings>(jwtSettings);
            //services.Configure<AmadeusSettings>(Configuration.GetSection("AmadeusSettings"));
            services.AddIdentity<User, Role>(options => 
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;;
                options.Password.RequireUppercase = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1d);
                options.Lockout.MaxFailedAccessAttempts = 5;
            }).AddEntityFrameworkStores<MyDataContext>().AddDefaultTokenProviders();
            //this is from our extensions
            // I also moved Authorization and JWT Authententication into an extension class - UBAInterviewPrepAPI.Extensions.AuthExtensions
            services.AddAuth(jwtSettings);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDigitalTravelService, DigitalTravelService>();
            services.AddScoped<ICarRepository, CarRepository>();
            // Faith moved Swagger DI into a separate Extension class because it looks too gigantic here disfiguring startup.cs
            // You can find the Extension class here - UBAInterviewPrepAPI.Extensions
            services.ConfigureSwagger();
            services.AddHangfire(x => x.UseSQLiteStorage(Configuration.GetConnectionString("SQLiteDBConn")));
            services.AddHangfireServer();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            //app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                var prefix = string.IsNullOrWhiteSpace(options.RoutePrefix) ? "." : "..";
                options.SwaggerEndpoint($"{prefix}/swagger/v1/swagger.json", "DigitalTravels API Swagger UI v1");
            });
            // I configured this by extending IApplicationBuilder inside of an extension class that I created 
            //UBAInterviewPrepAPI.Extensions.AuthExtensions
            app.UseAuth(); 
            app.UseHangfireDashboard();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
