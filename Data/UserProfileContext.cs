using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProxyApp.Migrations;

namespace ProxyApp.Data
{
    public class UserProfileContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public UserProfileContext() : base("name=UserProfileContext")
        {
            Database.SetInitializer<UserProfileContext>(new DbInit());
            Database.SetInitializer<UserProfileContext>(new DbInit2());
            Database.SetInitializer<UserProfileContext>(new DbInit3());
        }

        public System.Data.Entity.DbSet<ProxyApp.Models.UserProfile> UserProfiles { get; set; }
    }

    public class DbInit : CreateDatabaseIfNotExists<UserProfileContext>
    {
        protected override void Seed(UserProfileContext context)
        {
            base.Seed(context);
        }
    }

    public class DbInit2 : MigrateDatabaseToLatestVersion<UserProfileContext, Configuration>
    {
        
    }

    public class DbInit3 : DropCreateDatabaseIfModelChanges<UserProfileContext>
    {
        protected override void Seed(UserProfileContext context)
        {
            base.Seed(context);
        }
    }


}
