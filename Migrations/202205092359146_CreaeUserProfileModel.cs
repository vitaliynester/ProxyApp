namespace ProxyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreaeUserProfileModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        user_profile_id = c.Int(nullable: false, identity: true),
                        user_profile_first_name = c.String(nullable: true, maxLength: 255),
                        user_profile_surname = c.String(nullable: true, maxLength: 255),
                        user_profile_patronymic = c.String(nullable: true, maxLength: 255),
                        user_profile_phone = c.String(nullable: false, maxLength: 255),
                        user_profile_code = c.String(nullable: false, maxLength: 255),
                        user_profile_guid = c.String(nullable: true, maxLength: 255),
                        user_profile_med_org_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.user_profile_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserProfiles");
        }
    }
}
