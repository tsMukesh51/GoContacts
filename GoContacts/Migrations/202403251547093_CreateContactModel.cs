namespace GoContacts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateContactModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Email = c.String(nullable: false, maxLength: 255),
                        Phone = c.String(nullable: false, maxLength: 15),
                        Address = c.String(nullable: false, maxLength: 2000),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contacts");
        }
    }
}
