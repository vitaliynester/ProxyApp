namespace ProxyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdayField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "user_profile_birthday", c => c.DateTime(nullable: true, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "user_profile_birthday");
        }
    }
}
