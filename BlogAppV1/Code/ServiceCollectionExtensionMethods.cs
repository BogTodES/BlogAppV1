using BlogAppV1.BusinessLogic;
using BlogAppV1.Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.Code
{
    public static class ServiceCollectionExtensionMethods
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<UserAccountService>();
            services.AddScoped<UserInfoService>();
            services.AddScoped<UserBlogService>();
            services.AddScoped<BlogService>();
            services.AddScoped<SectionsService>();
            services.AddScoped<PostService>();
            return services;
        }

        public static IServiceCollection AddCurrentUser(this IServiceCollection services)
        {
            services.AddScoped(serv =>
            {
                var accessor = serv.GetService<IHttpContextAccessor>();
                var httpContext = accessor.HttpContext;

                return new CurrentUserDto
                {
                    IsAuthenticated = httpContext.User.Identity.IsAuthenticated,
                    Id = httpContext.User.Claims?.FirstOrDefault(clm => clm.Type == "Id")?.Value,
                    Username = httpContext.User.Identity.Name
                };
            });

            return services;
        }

        /*public static IServiceCollection AddUserInfo(this IServiceCollection services)
        {
            services.AddScoped<UserInfoService>();
            return services;
        }*/
    }
}
