using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace ProjeEmlak.Identity
{
    public class IdentityInitializer:CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            if (!context.Roles.Any(i=>i.Name=="Admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "Admin", Description = "Admin Rolü" };
                manager.Create(role);
            }
            if (!context.Roles.Any(i => i.Name == "User"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "User", Description = "User Rolü" };
                manager.Create(role);
            }
            if (!context.Users.Any(i=>i.Name=="Admin"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "bahadir", Surname = "akyazi", UserName = "bahadir", Email = "bahadir@gmail.com" };
                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "Admin");
                manager.AddToRole(user.Id, "User");
            }
            if (!context.Users.Any(i => i.Name == "ahmet"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "ahmet", Surname = "mehmet", UserName = "ahmet", Email = "ahmet@gmail.com" };
                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "User");
            }
            base.Seed(context); 
        }
    }
}