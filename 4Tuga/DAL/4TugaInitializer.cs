using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using _4Tuga.Models;
using System.Net;
using _4Tuga.DAL;
using System.Data.Entity;

namespace _4Tuga.DAL
{
    public class _4TugaInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext> 
    {

       
        protected override void Seed(ApplicationDbContext context)
        {

            //create admin
            var Admin = new List<ApplicationUser>
            {
            new ApplicationUser {Id="111a111a-11aa-1aa1-1aaa-aaaa111aa1aa",Name="MasterAdmin",Gender ="Male", DateofBirth = DateTime.Now  ,Email="SuperAdmin@Super.com", EmailConfirmed= false, PasswordHash="ANCsC3NOnuNdS7bsfe6AFR7LuatLP3naRsOPrPvLU5f6GrHi0+fED6pfyNh7Bw3bjA==", SecurityStamp=null, PhoneNumber=null, PhoneNumberConfirmed=false,TwoFactorEnabled=false,LockoutEndDateUtc=null,LockoutEnabled=false,AccessFailedCount=0,UserName="SuperAdmin@Super.com" },
            };
            Admin.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            //creating admin role
            var AdminRole = new List<IdentityRole>
            {
            new IdentityRole{Id="22a1a11a-1111-1a11-11a1-aa11a11a1a11",Name="Admin",},
      
            };

            AdminRole.ForEach(s => context.Roles.Add(s));
            context.SaveChanges();

            ////put role into admin
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            userManager.AddToRole("111a111a-11aa-1aa1-1aaa-aaaa111aa1aa", "Admin");

             context.SaveChanges();
             base.Seed(context);
        }
    }
}