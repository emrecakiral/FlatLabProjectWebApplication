namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManagersUpdate2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Managers", "Company_CompanyID", "dbo.Companies");
            DropIndex("dbo.Managers", new[] { "Company_CompanyID" });
            RenameColumn(table: "dbo.Managers", name: "Company_CompanyID", newName: "CompanyID");
            AlterColumn("dbo.Managers", "CompanyID", c => c.Int(nullable: false));
            CreateIndex("dbo.Managers", "CompanyID");
            AddForeignKey("dbo.Managers", "CompanyID", "dbo.Companies", "CompanyID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Managers", "CompanyID", "dbo.Companies");
            DropIndex("dbo.Managers", new[] { "CompanyID" });
            AlterColumn("dbo.Managers", "CompanyID", c => c.Int());
            RenameColumn(table: "dbo.Managers", name: "CompanyID", newName: "Company_CompanyID");
            CreateIndex("dbo.Managers", "Company_CompanyID");
            AddForeignKey("dbo.Managers", "Company_CompanyID", "dbo.Companies", "CompanyID");
        }
    }
}
