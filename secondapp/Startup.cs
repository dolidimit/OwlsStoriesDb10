using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using secondapp.Data;
using System;
using secondapp.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using secondapp.Services.Stories;
using secondapp.Services.Books;
using secondapp.Services.Admin;
using secondapp.Data.Models;
using secondapp.Services.Posts;
using secondapp.Services.Users;
using secondapp.Services.Favourites;
using secondapp.Services.Events;

namespace secondapp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookAppDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<User>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
            })
             .AddRoles<IdentityRole>()
             .AddEntityFrameworkStores<BookAppDbContext>();

            services.AddControllersWithViews();

            services.AddTransient<IStoryService, StoryService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IPostsService, PostsService>();
            services.AddTransient<IEventService, EventsService>();
            services.AddTransient<IFavouritesService, FavouritesService>();         
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAdminService, AdminService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.PrepareDatabase();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });

            //app.ApplicationServices.GetService<BookAppDbContext>().Database.Migrate();

        }
    }
}
