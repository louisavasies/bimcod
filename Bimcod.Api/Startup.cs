using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Bimcod.Api.Models;
using Microsoft.EntityFrameworkCore;
using Bimcod.Api.Repositories;
using Bimcod.Api.Mappers;
using Bimcod.Api.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Bimcod.Api.Utilities;
using Bimcod.Api.Controllers;

namespace Bimcod.Api
{
    public class Startup
    {
        private static string sqlConnection = @"Server=(localdb)\MSSQLLocalDB;Database=Bimcod;Trusted_Connection=True;ConnectRetryCount=0";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });

            services.AddMvc();

            services.AddDbContext<BimcodContext>(options => options.UseSqlServer(sqlConnection));

            services.AddScoped<CarOptionRepository, CarOptionRepository>();
            services.AddScoped<CarRepository, CarRepository>();
            services.AddScoped<OptionRepository, OptionRepository>();
            services.AddScoped<ModuleRepository, ModuleRepository>();
            services.AddScoped<OptionPartRepository, OptionPartRepository>();
            services.AddScoped<PartRepository, PartRepository>();
            services.AddScoped<UserRepository, UserRepository>();
            services.AddScoped<AuthenticationService, AuthenticationService>();
            services.AddScoped<IEntityMapper<CarOptionViewModel, CarOption>, CarOptionViewModelToEntityMapper>();
            services.AddScoped<IEntityMapper<CarOption, CarOptionViewModel>, CarOptionToViewModelMapper>();
            services.AddScoped<IEntityMapper<CarViewModel, Car>, CarViewModelToEntityMapper>();
            services.AddScoped<IEntityMapper<Car, CarViewModel>, CarToViewModelMapper>();
            services.AddScoped<IEntityMapper<ModuleViewModel, Module>, ModuleViewModelToEntityMapper>();
            services.AddScoped<IEntityMapper<Module, ModuleViewModel>, ModuleToViewModelMapper>();
            services.AddScoped<IEntityMapper<OptionPartViewModel, OptionPart>, OptionPartViewModelToEntityMapper>();
            services.AddScoped<IEntityMapper<OptionPart, OptionPartViewModel>, OptionPartToViewModelMapper>();
            services.AddScoped<IEntityMapper<OptionViewModel, Option>, OptionViewModelToEntityMapper>();
            services.AddScoped<IEntityMapper<Option, OptionViewModel>, OptionToViewModelMapper>();
            services.AddScoped<IEntityMapper<PartViewModel, Part>, PartViewModelToEntityMapper>();
            services.AddScoped<IEntityMapper<Part, PartViewModel>, PartToViewModelMapper>();
            services.AddScoped<IEntityMapper<UserViewModel, User>, UserViewModelToEntityMapper>();
            services.AddScoped<IEntityMapper<User, UserViewModel>, UserToViewModelMapper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                sqlConnection = @"Server=(localdb)\MSSQLLocalDB;Database=Bimcod;Trusted_Connection=True;ConnectRetryCount=0";
            }
            else
            {
                sqlConnection = @"Server=tcp:bimcod.database.windows.net,1433;Initial Catalog=BimcodDB;Persist Security Info=False;User ID={louisavasies};Password={Bimcodyzacdr2018};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            }
            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
