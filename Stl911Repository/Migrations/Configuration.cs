namespace Stl911Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Stl911Repository.ServiceCallContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Stl911Repository.ServiceCallContext context)
        {
            //  This method will be called after migrating to the latest version.

            var versionRow = context.AppInformation.FirstOrDefault();
            if (versionRow == null)
            {
                context.AppInformation.Add(new Stl911Domain.AppInformation { Version = "1.0", LastSyncTime = DateTime.Now.AddHours(-1) });
            }

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
