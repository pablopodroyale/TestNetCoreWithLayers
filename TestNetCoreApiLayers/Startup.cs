using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestNetCore.Bussines;
using TestNetCore.Core.Bussines;
using TestNetCore.Core.Contracts;
using TestNetCore.Dal;
using Swashbuckle.AspNetCore.Swagger;
using FluentValidation;
using TestNetCore.Core.Dto;
using TestNetCore.Api.Validators;
using FluentValidation.AspNetCore;
using TestNetCore.Api.Extensions;
using TestNetCore.Core.Model;
using Microsoft.AspNetCore.Identity;
using TestNetCore.Dal.Contracts;
using TestNetCore.Core.Repository;
using TestNetCore.Dal.Repository;
using Castle.Core.Logging;
using Serilog.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace TestNetCoreApiLayers
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var key = Encoding.UTF8.GetBytes(Configuration["ApplicattionSettings:Jwt_Secret"]);

            services.Configure<TestNetCore.Core.Shared.ApplicattionSettings>(Configuration.GetSection("ApplicattionSettings"));
            services.AddControllers();
            services.AddTransient<IUserBussines, UserBussines>();
            services.AddTransient<IUserApplicattionDal, UserApplicattionDal>();
            services.AddTransient<IUserRepository, ApplicattionUserRepository>();
            services.AddAutoMapper(typeof(Startup));
            services.ConfigureApiBehavior();
            services.ConfigureSwagger();
            services.ConfigureMvc();
            services.AddDbContext<TestNetCoreDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Default"), sqlServerOptions => sqlServerOptions.MigrationsAssembly("TestNetCore.Dal")));
            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<TestNetCoreDbContext>()
                .AddDefaultTokenProviders();
            services.ConfigureCors();
            services.AddAuthentication(x =>
                {

                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                }
            ).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
            services.ConfigureIdentityOptions();
            services.AddMvc().AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (ctx, next) =>
               {
                   await next();
                   if (ctx.Response.StatusCode == 204)
                   {
                       ctx.Response.ContentLength = 0;
                   }
               }
            );

            app.UseHttpsRedirection();
            app.UseCors("AllowAll");

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();


            app.UseMiddleware<SerilogExtension>();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseHttpsRedirection();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestNetCore V1");
            });

            serviceProvider.GetService<TestNetCoreDbContext>().Database.EnsureCreated();

            ApplicationDbInitializer.SeedUsers(userManager, roleManager);

        }
    }
}
