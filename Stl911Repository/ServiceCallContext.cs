using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stl911Repository
{
    public class ServiceCallContext : DbContext
    {
        public ServiceCallContext() : base("Stl911Connection")
        {
        }

        public DbSet<Stl911Domain.ServiceCall> ServiceCall { get; set; }
        public DbSet<Stl911Domain.AppInformation> AppInformation { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
