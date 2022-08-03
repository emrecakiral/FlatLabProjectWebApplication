namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobTableUpdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Jobs", "Urgency");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "Urgency", c => c.Boolean(nullable: false));
        }
    }
}
