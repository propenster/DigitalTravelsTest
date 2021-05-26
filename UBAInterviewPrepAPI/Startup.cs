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
using UBAInterviewPrepAPI.ConfigModels;
using UBAInterviewPrepAPI.Data;
using UBAInterviewPrepAPI.Data.Repositories;
using UBAInterviewPrepAPI.Data.UOW;
using UBAInterviewPrepAPI.Extensions;
using UBAInterviewPrepAPI.Models.Auth;
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
            var jwtSettings = Configuration.GetSection("Jwt").Get<JwtSettings>();
            services.AddDbContext<MyDataContext>(options => options.UseSqlite(Configuration.GetConnectionString("SQLiteDBConn")));
            services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));
            services.AddIdentity<User, Role>(options => 
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;;
                options.Password.RequireUppercase = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1d);
                options.Lockout.MaxFailedAccessAttempts = 5;
            }).AddEntityFrameworkStores<MyDataContext>().AddDefaultTokenProviders();
            //this is from our extensions
            services.AddAuth(jwtSettings);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IDigitalTravelService, DigitalTravelService>();
            services.AddSwaggerGen(option => option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Cars API with Identity", Description = "This is the Cars API with Identity included", Version = "v1"}));

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
                options.SwaggerEndpoint($"{prefix}/swagger/v1/swagger.json", "Cars API Swagger UI");
            });
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
