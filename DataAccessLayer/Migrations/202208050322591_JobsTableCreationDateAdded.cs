namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobsTableCreationDateAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "CompletionDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Jobs", "CreationDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Jobs", "RemainingTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "RemainingTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Jobs", "CreationDate");
            DropColumn("dbo.Jobs", "CompletionDate");
        }
    }
}
