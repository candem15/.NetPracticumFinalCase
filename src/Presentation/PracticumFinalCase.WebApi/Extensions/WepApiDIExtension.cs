using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;

namespace PracticumFinalCase.WebApi.Extensions
{
    public static class WepApiDIExtension
    {
        public static void AddRedisDependencyInjection(this IServiceCollection services, IConfiguration Configuration)
        {
            //redis 
            var configurationOptions = new ConfigurationOptions();
            configurationOptions.EndPoints.Add(Configuration["Redis:Host"], Convert.ToInt32(Configuration["Redis:Port"]));
            int.TryParse(Configuration["Redis:DefaultDatabase"], out int defaultDatabase);
            configurationOptions.DefaultDatabase = defaultDatabase;
            services.AddStackExchangeRedisCache(options =>
            {
                options.ConfigurationOptions = configurationOptions;
                options.InstanceName = Configuration["Redis:InstanceName"];
            });
        }

        public static void AddCustomizeSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Param Practicum Final Case", Version = "v1.0" });
                c.OperationFilter<SwaggerFileOperationFilterExtension>();

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Techa Management for IT Company",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // Must be lower case
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}
                });
            });
        }
    }
}
