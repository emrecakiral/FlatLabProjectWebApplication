namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MailDocumentAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mails", "Document", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mails", "Document");
        }
    }
}
