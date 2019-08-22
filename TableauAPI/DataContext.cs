using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using TableauAPI.Models;

namespace TableauAPI
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=DefaultConnection")
        {
            this.Database.CommandTimeout = 180;

        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    throw new UnintentionalCodeFirstException();
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //DONT DO THIS ANYMORE
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Vote>().ToTable("Votes")
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<AlexaSKill> AlexaSKill { get; set; }

        public DbSet<SalesSkill> SalesSkill { get; set; }


    }
}