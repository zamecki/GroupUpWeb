using GroupUpWeb.Helpers.EF.Mapping;
using GroupUpWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace GroupUpWeb.Helpers
{
    public class GroupUpContext : DbContext
    {

        static GroupUpContext()
        {
            Database.SetInitializer<GroupUpContext>(null);
        }

        public GroupUpContext()
                : base(nameOrConnectionString: "GroupUpConnectionString") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            MappingConfig.ConfigureMap(modelBuilder);
        }

        #region DbSets

        public DbSet<User> User { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<GroupUser> GroupUser { get; set; }
        public DbSet<UserUser> UserUser { get; set; }
        #endregion
    }
}