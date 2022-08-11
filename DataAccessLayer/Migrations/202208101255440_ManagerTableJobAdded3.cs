namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManagerTableJobAdded3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "Priority", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "Priority", c => c.Byte(nullable: false));
        }
    }
}
