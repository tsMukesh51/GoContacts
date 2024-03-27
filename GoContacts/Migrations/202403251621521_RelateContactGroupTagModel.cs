namespace GoContacts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelateContactGroupTagModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactGroupTags",
                c => new
                    {
                        ContactId = c.Int(nullable: false),
                        GroupTagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ContactId, t.GroupTagId })
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: false)
                .ForeignKey("dbo.GroupTags", t => t.GroupTagId, cascadeDelete: true)
                .Index(t => t.ContactId)
                .Index(t => t.GroupTagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactGroupTags", "GroupTagId", "dbo.GroupTags");
            DropForeignKey("dbo.ContactGroupTags", "ContactId", "dbo.Contacts");
            DropIndex("dbo.ContactGroupTags", new[] { "GroupTagId" });
            DropIndex("dbo.ContactGroupTags", new[] { "ContactId" });
            DropTable("dbo.ContactGroupTags");
        }
    }
}
