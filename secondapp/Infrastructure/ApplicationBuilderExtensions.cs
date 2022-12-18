using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using secondapp.Data;
using secondapp.Data.Models;
using static secondapp.Data.WebConstants;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace secondapp.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {

            using var scopedServices = app.ApplicationServices.CreateScope();
            var services = scopedServices.ServiceProvider;

            MigrateDatabase(services);
            SeedGenres(services);
            SeedAdministrator(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<BookAppDbContext>();

            data.Database.Migrate();
        }

        private static void SeedGenres(IServiceProvider services)
        {

            var data = services.GetRequiredService<BookAppDbContext>();

            if(data.Genres.Any())
            {
                return;
            }

            data.Genres.AddRange(new[]
            {
                new Genre {Name = "Romance" },
                new Genre {Name = "Comedy" },
                new Genre {Name = "Tragedy" },
                new Genre {Name = "Poetry" },
                new Genre {Name = "Thriller" },
                new Genre {Name = "Fiction" },
                new Genre {Name = "History" },
                new Genre {Name = "Education" },
                new Genre {Name = "Fashion" },
                new Genre {Name = "Design" },
                new Genre {Name = "Science" },
                new Genre {Name = "Psychology" },
                new Genre {Name = "Children and Youth" },
                new Genre {Name = "Politics" },
                new Genre {Name = "Art" }
            });

            data.SaveChanges();

        }

        private static void SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();


            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(AdministratorRoleName))
                    {
                        return;
                    }

                    var role = new IdentityRole { Name = AdministratorRoleName };

                    await roleManager.CreateAsync(role);

                    const string adminEmail = "ver56destre3io@gmail.com";
                    const string adminPassword = "gyu8i7876trthguyi8SAe4ghh934#huQSp)";

                    var user = new User
                    {
                        Email = adminEmail,
                        UserName = adminEmail,
                        FullName = "Admin"
                    };

                    await userManager.CreateAsync(user, adminPassword);

                    await userManager.AddToRoleAsync(user, role.Name);
                })
                .GetAwaiter()
                .GetResult();


        }
    }
}
