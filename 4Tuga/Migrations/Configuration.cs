namespace _4Tuga.Migrations
{
    using _4Tuga.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_4Tuga.DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(_4Tuga.DAL.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //



            //create admin
            //var Admin = new List<ApplicationUser>
            //{
            //     new ApplicationUser {Id="111a111a-11aa-1aa1-1aaa-aaaa111aa1aa",Name="MasterAdmin",Gender ="Male", DateofBirth = DateTime.Now  ,Email="SuperAdmin@Super.com", EmailConfirmed= false, PasswordHash="AJQeal9eFO/YTOtjI7xu7WDwjCCp0AEYLrMBWN6stvqpI/28A0+/FbTDBMP1dAr8KQ==", SecurityStamp=null, PhoneNumber=null, PhoneNumberConfirmed=false,TwoFactorEnabled=false,LockoutEndDateUtc=null,LockoutEnabled=false,AccessFailedCount=0,UserName="SuperAdmin@Super.com" },
            //};
            //Admin.ForEach(s => context.Users.Add(s));
            //context.SaveChanges();

            ////creating admin role
            //var AdminRole = new List<IdentityRole>
            //{
            //new IdentityRole{Id="22a1a11a-1111-1a11-11a1-aa11a11a1a11",Name="Admin",},
      
            //};
            //AdminRole.ForEach(s => context.Roles.Add(s));
            //context.SaveChanges();

            //put role into admin
            //var userStore = new UserStore<ApplicationUser>(context);
            //var userManager = new UserManager<ApplicationUser>(userStore);
            //userManager.AddToRole("111a111a-11aa-1aa1-1aaa-aaaa111aa1aa", "Admin");
            //context.SaveChanges();
        }
    }
}
