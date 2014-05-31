namespace BarterWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        LinkToEbay = c.String(),
                        LinkToAmazon = c.String(),
                        Email = c.String(nullable: false, maxLength: 50),
                        TwitterAccount = c.String(),
                        BlogURL = c.String(),
                        LinkedInUrl = c.String(),
                        CompanyUrl = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserProfile");
        }
    }
}
