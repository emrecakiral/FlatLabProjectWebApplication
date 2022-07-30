namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MailImportance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mails", "Importance", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mails", "Importance");
        }
    }
}
