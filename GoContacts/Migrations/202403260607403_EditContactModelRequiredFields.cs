namespace GoContacts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditContactModelRequiredFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "Email", c => c.String(maxLength: 255));
            AlterColumn("dbo.Contacts", "Birthday", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Birthday", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contacts", "Email", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
