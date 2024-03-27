namespace GoContacts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateGroupTagModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupTags", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.GroupTags", new[] { "ApplicationUserId" });
            DropTable("dbo.GroupTags");
        }
    }
}
