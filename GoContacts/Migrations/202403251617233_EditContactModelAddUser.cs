namespace GoContacts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditContactModelAddUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Contacts", "ApplicationUserId");
            AddForeignKey("dbo.Contacts", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Contacts", new[] { "ApplicationUserId" });
            DropColumn("dbo.Contacts", "ApplicationUserId");
        }
    }
}
