namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManagerIDNullable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Jobs", new[] { "ManagerID" });
            AlterColumn("dbo.Jobs", "ManagerID", c => c.Int());
            CreateIndex("dbo.Jobs", "ManagerID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Jobs", new[] { "ManagerID" });
            AlterColumn("dbo.Jobs", "ManagerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Jobs", "ManagerID");
        }
    }
}
