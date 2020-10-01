using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAppV1.Code;
using BlogAppV1.DataAccess;
using BlogAppV1.DataAccess.EFConfig;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;

namespace BlogAppV1
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
            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(Startup));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<BlogAppDBContext>();
            services.AddScoped<UnitOfWork>();

            services.AddBusinessLogic();
            services.AddCurrentUser();


            services.AddAuthentication("BlogAppCookies")
                .AddCookie("BlogAppCookies", options =>
                {
                    options.AccessDeniedPath = new PathString("/Account/Login");
                    options.LoginPath = new PathString("/Account/Login");
                });
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "BlogPage",
                    pattern: "Blog/ShowBlogWith/{id}");

                endpoints.MapControllerRoute(
                    name: "EditBlogPage",
                    pattern: "Blog/EditBlogId/{id}");

                endpoints.MapControllerRoute(
                    name: "BlogListForUser",
                    pattern: "UserBlog/BlogsOfUser/{username}");

                endpoints.MapControllerRoute(
                    name: "ProfileOf",
                    pattern: "UserInfo/ProfileOf/{username}");

                endpoints.MapControllerRoute(
                    name: "RegisterPage",
                    pattern: "Account/Register");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
