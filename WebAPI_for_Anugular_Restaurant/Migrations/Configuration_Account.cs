using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace WebAPI_for_Anugular_Restaurant.Migrations
{
    public class Configuration_Account: DbMigrationsConfiguration<WebAPI_for_Anugular_Restaurant.Models.ApplicationDbContext>
    {
        public Configuration_Account()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebAPI_for_Anugular_Restaurant.Models.ApplicationDbContext context)
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
        }
    }
}