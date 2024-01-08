using KirilsShop.Data.Static;
using KirilsShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace KirilsShop.Data
{
    public class DBIntializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.CarBrands.Any())
                {
                    context.CarBrands.AddRange(new List<Models.Categories.Brand>()
                {
                        new Models.Categories.Brand()
                        {

                           Name = "Audi",
                           

                        },
                         new Models.Categories.Brand()
                        {

                           Name = "Bmw",


                        },
                        new Models.Categories.Brand()
                        {

                           Name = "Volkswagen",


                        },
                        new Models.Categories.Brand()
                        {

                           Name = "Skoda",


                        },
                        new Models.Categories.Brand()
                        {

                           Name = "Seat",


                        },
                        new Models.Categories.Brand()
                        {

                           Name = "Opel",


                        },
                        new Models.Categories.Brand()
                        {

                           Name = "Toyota",


                        },
                        new Models.Categories.Brand()
                        {

                           Name = "Honda",


                        },
                        new Models.Categories.Brand()
                        {

                           Name = "Nissan",


                        },
                        new Models.Categories.Brand()
                        {

                           Name = "Ford",


                        },
                        new Models.Categories.Brand()
                        {

                           Name = "Pegeout",


                        }, new Models.Categories.Brand()
                        {

                           Name = "Reanult",


                        }, new Models.Categories.Brand()
                        {

                           Name = "Chevrolet",


                        }, new Models.Categories.Brand()
                        {

                           Name = "Fiat",


                        },







                });
                }

                if (!context.CarYOPs.Any())
                {
                    context.CarYOPs.AddRange(new List<Models.Categories.YearOfProduction>()
                {
                        new Models.Categories.YearOfProduction()
                        {

                           Name = "1999",


                        },
                        new Models.Categories.YearOfProduction()
                        {

                           Name = "2000",


                        },
                        new Models.Categories.YearOfProduction()
                        {

                           Name = "2001",


                        },
                        new Models.Categories.YearOfProduction()
                        {

                           Name = "2002",


                        },
                        new Models.Categories.YearOfProduction()
                        {

                           Name = "2003",


                        },
                        new Models.Categories.YearOfProduction()
                        {

                           Name = "2004",


                        },
                        new Models.Categories.YearOfProduction()
                        {

                           Name = "2005",


                        },
                        new Models.Categories.YearOfProduction()
                        {

                           Name = "2006",


                        },
                        new Models.Categories.YearOfProduction()
                        {

                           Name = "2007",


                        },
                        new Models.Categories.YearOfProduction()
                        {

                           Name = "2008",


                        },
                        new Models.Categories.YearOfProduction()
                        {

                           Name = "2009",


                        },
                        new Models.Categories.YearOfProduction()
                        {

                           Name = "2010",


                        },
                        new Models.Categories.YearOfProduction()
                        {

                           Name = "2011",


                        },
                        new Models.Categories.YearOfProduction()
                        {

                           Name = "2012",


                        },
                        new Models.Categories.YearOfProduction()
                        {

                           Name = "2013",


                        },
                        new Models.Categories.YearOfProduction()
                        {

                           Name = "2014",


                        },
                        new Models.Categories.YearOfProduction()
                        {

                           Name = "2015",


                        },
                        new Models.Categories.YearOfProduction()
                        {

                           Name = "2016",


                        },
                        new Models.Categories.YearOfProduction()
                        {

                           Name = "2017",


                        },
                         new Models.Categories.YearOfProduction()
                        {

                           Name = "2018",


                        },
                        new Models.Categories.YearOfProduction()
                        {

                           Name = "2019",


                        },
                        new Models.Categories.YearOfProduction()
                        {

                           Name = "2020",


                        },
                        new Models.Categories.YearOfProduction()
                        {

                           Name = "2021",


                        },
                         new Models.Categories.YearOfProduction()
                        {

                           Name = "2022",


                        },
                          new Models.Categories.YearOfProduction()
                        {

                           Name = "2023",


                        },

                 });
                }

                if (!context.CarColors.Any())
                {
                    context.CarColors.AddRange(new List<Models.Categories.Colour>()
                {
                        new Models.Categories.Colour()
                        {

                           Name = "White",


                        },
                        new Models.Categories.Colour()
                        {

                           Name = "Gray",


                        },
                        new Models.Categories.Colour()
                        {

                           Name = "Black",


                        },
                        new Models.Categories.Colour()
                        {

                           Name = "Blue",


                        },
                        new Models.Categories.Colour()
                        {

                           Name = "Green",


                        },
                         new Models.Categories.Colour()
                        {

                           Name = "Yellow",


                        },
                        new Models.Categories.Colour()
                        {

                           Name = "Orange",


                        },
                        new Models.Categories.Colour()
                        {

                           Name = "Pink",


                        },

                 });
                }

                if (!context.CarBodys.Any())
                {
                    context.CarBodys.AddRange(new List<Models.Categories.Body>()
                {
                        new Models.Categories.Body()
                        {

                           Name = "Hatchback",


                        },
                        new Models.Categories.Body()
                        {

                           Name = "Minivan",


                        },
                        new Models.Categories.Body()
                        {

                           Name = "CUV",


                        },
                        new Models.Categories.Body()
                        {

                           Name = "Couple",


                        },
                        new Models.Categories.Body()
                        {

                           Name = "Supercar",


                        },
                         new Models.Categories.Body()
                        {

                           Name = "Cabriolet",


                        },
                        new Models.Categories.Body()
                        {

                           Name = "Sedan",


                        },
                        new Models.Categories.Body()
                        {

                           Name = "SUV",


                        },
                         new Models.Categories.Body()
                        {

                           Name = "Universal",


                        },
                          new Models.Categories.Body()
                        {

                           Name = "Sportcar",


                        },


                 });
                }

                if (!context.CarFuels.Any())
                {
                    context.CarFuels.AddRange(new List<Models.Categories.Fuel>()
                {
                        new Models.Categories.Fuel()
                        {

                           Name = "Gasoline",


                        },
                        new Models.Categories.Fuel()
                        {

                           Name = "Diesel",


                        },
                        new Models.Categories.Fuel()
                        {

                           Name = "CNG",


                        },
                        new Models.Categories.Fuel()
                        {

                           Name = "Bio-Diesel",


                        },
                        new Models.Categories.Fuel()
                        {

                           Name = "Ethanol",


                        },
                         new Models.Categories.Fuel()
                        {

                           Name = "Hybrid",


                        },
                        new Models.Categories.Fuel()
                        {

                           Name = "Electro",


                        },


                 });
                }
                if (!context.CarOrigins.Any())
                {
                    context.CarOrigins.AddRange(new List<Models.Categories.Origin>()
                {
                        new Models.Categories.Origin()
                        {

                           Name = "England",


                        },
                        new Models.Categories.Origin()
                        {

                           Name = "USA",


                        },
                        new Models.Categories.Origin()
                        {

                           Name = "Italy",


                        },
                        new Models.Categories.Origin()
                        {

                           Name = "Germany",


                        },
                        new Models.Categories.Origin()
                        {

                           Name = "Australia",


                        },
                         new Models.Categories.Origin()
                        {

                           Name = "Japam",


                        },
                        new Models.Categories.Origin()
                        {

                           Name = "China",


                        },
                         new Models.Categories.Origin()
                        {

                           Name = "Sweden",


                        },
                         new Models.Categories.Origin()
                        {

                           Name = "France",


                        },
                        new Models.Categories.Origin()
                        {

                           Name = "Czech Republic",


                        },


                 });
                }

                context.SaveChanges();

            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@rtx.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "1234AbAb45sadsadAdas@");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


               
            }
        
        }

    }


}
