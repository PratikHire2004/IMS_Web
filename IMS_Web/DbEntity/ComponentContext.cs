using IMS_Web.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS_Web.DbEntity
{
    public class ComponentContext : DbContext
    {
        public ComponentContext(DbContextOptions<ComponentContext> options)
          : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResponseData>(e => { 
                e.HasNoKey();
                e.Property(v => v.ComponenetName).HasColumnName("ComponenetName");
                e.Property(v => v.Quantity).HasColumnName("Quantity");
            });
        }

        public DbSet<tbl_schema> schema { get; set; }
        public DbSet<tbl_components> components { get; set; }
        public DbSet<tbl_depended> depended { get; set; }
        public DbSet<ResponseData> singleComponentdata { get; set; }

    }
}
