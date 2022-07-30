namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messagess : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Mails", "Importance", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Mails", "Importance", c => c.Int(nullable: false));
        }
    }
}
