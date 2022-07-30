namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class message_max_lenght : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Mails", "Message", c => c.String(maxLength: 2000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Mails", "Message", c => c.String(maxLength: 1000));
        }
    }
}
