using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core;
using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Domain.Options;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Domain.Checks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using MediatR;
using Domain.Application.Queries;
using Domain.Application.Commands;
using Domain.Application.Behaviours;
using vagbhat.api.Filters;
using vagbhat.api.Authorization;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace vagbhat.api
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
            services.BuildMediator();
            services.AddCustomDbContext(Configuration)
                .AddCustomIntegrations()
                .AddCustomSwagger()
                .AddCustomIdentity()
                .AddCustomAuthentication(Configuration)
                .AddCustomAuthorization()
                .AddCustomMvc()
                .AddAutoMapper(typeof(Startup))
                .AddHealthChecks()
               .AddDbContextCheck<EntitiesContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = async (context, report) =>
                 {
                     context.Response.ContentType = "application/json";
                     var healthCheckResponse = new HealthCheckResponse
                     {
                         Status = report.Status.ToString(),
                         Duration = report.TotalDuration,
                         HealthChecks = report.Entries.Select(x => new HealthCheck
                         {
                             Component = x.Key,
                             Status = x.Value.Status.ToString(),
                             Description = x.Value.Description
                         })
                     };
                     await context.Response.WriteAsync(JsonConvert.SerializeObject(healthCheckResponse));
                 }
            });

            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);
            app.UseSwagger(option =>
            {
                option.RouteTemplate = swaggerOptions.JsonRoute;
            });

            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);
            });

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    static class CustomExtensionsMethods
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<EntitiesContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
        public static IServiceCollection AddCustomIntegrations(this IServiceCollection services)
        {
            services.AddScoped<EntitiesContext>();            
            services.AddScoped(typeof(IEntityRepository<>), typeof(EntityRepository<>));            
            services.AddScoped<IUnitOfWork, UnitOfWork>();            
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionBehaviour<,>));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAuthorizationHandler, IsUserDeletedHandler>();

            services.AddScoped<IAccessService, AccessService>();
            services.AddScoped<IRefreshTokenService, RefreshTokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAssociationService, AssociationService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ICommonService, CommonService>();

            return services;
        }
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Vagbhat API", Version = "v1" });

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[0] }
                };

                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization Header using Bearer Scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id="Bearer",
                                Type=ReferenceType.SecurityScheme
                            }
                        } ,new List<string>()
                    }
                });
            });
            return services;
        }
        public static IMediator BuildMediator(this IServiceCollection services)
        {
            services.AddScoped<ServiceFactory>(p => p.GetService);

            services.AddMediatR(typeof(GetUsersQueryHandler));
            services.AddMediatR(typeof(GetUserQueryAsyncHandler));
            services.AddMediatR(typeof(CreateTokenCommandAsyncHandler));
            services.AddMediatR(typeof(CreateRefreshTokenCommandAsyncHandler));

            var provider = services.BuildServiceProvider();

            return provider.GetRequiredService<IMediator>();
        }        
        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            services.AddControllers(config =>
            {
                config.Filters.Add(typeof(ApiExceptionFilter));
                //config.Filters.Add(new UnitOfWorkAsyncActionFilters());
            });

            return services;
        }
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(nameof(JwtSettings), jwtSettings);
            services.AddSingleton(jwtSettings);


            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateLifetime = true,
                RequireExpirationTime = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret))
            };            

            services.AddSingleton(tokenValidationParameters);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Events = new JwtBearerEvents()
                {
                    OnMessageReceived = context =>
                    {
                        if (context.Request.Query.ContainsKey("access_token"))
                        {
                            context.Token = context.Request.Query["access_token"];
                        }

                        return Task.CompletedTask;
                    }
                };

                options.SaveToken = true;
                options.TokenValidationParameters = tokenValidationParameters;
            });

            return services;
        }
        public static IServiceCollection AddCustomIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;

            })
                .AddEntityFrameworkStores<EntitiesContext>().AddDefaultTokenProviders();

            return services;
        }
        public static IServiceCollection AddCustomAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(CreatedPolicies.Deleted, policy =>
                {
                    policy.AddRequirements(new IsUserDeletedRequirement());
                });
            });

            return services;
        }
    }
}
