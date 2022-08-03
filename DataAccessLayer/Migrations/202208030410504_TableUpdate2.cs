namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableUpdate2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Managers", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Personnels", "CompanyID", "dbo.Companies");
            DropIndex("dbo.Personnels", new[] { "Manager_ManagerID" });
            DropIndex("dbo.Jobs", new[] { "Manager_ManagerID" });
            RenameColumn(table: "dbo.Personnels", name: "Manager_ManagerID", newName: "ManagerID");
            RenameColumn(table: "dbo.Jobs", name: "Manager_ManagerID", newName: "ManagerID");
            AlterColumn("dbo.Personnels", "ManagerID", c => c.Int(nullable: false));
            AlterColumn("dbo.Jobs", "ManagerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Personnels", "ManagerID");
            CreateIndex("dbo.Jobs", "ManagerID");
            AddForeignKey("dbo.Managers", "CompanyID", "dbo.Companies", "CompanyID");
            AddForeignKey("dbo.Personnels", "CompanyID", "dbo.Companies", "CompanyID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personnels", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Managers", "CompanyID", "dbo.Companies");
            DropIndex("dbo.Jobs", new[] { "ManagerID" });
            DropIndex("dbo.Personnels", new[] { "ManagerID" });
            AlterColumn("dbo.Jobs", "ManagerID", c => c.Int());
            AlterColumn("dbo.Personnels", "ManagerID", c => c.Int());
            RenameColumn(table: "dbo.Jobs", name: "ManagerID", newName: "Manager_ManagerID");
            RenameColumn(table: "dbo.Personnels", name: "ManagerID", newName: "Manager_ManagerID");
            CreateIndex("dbo.Jobs", "Manager_ManagerID");
            CreateIndex("dbo.Personnels", "Manager_ManagerID");
            AddForeignKey("dbo.Personnels", "CompanyID", "dbo.Companies", "CompanyID", cascadeDelete: true);
            AddForeignKey("dbo.Managers", "CompanyID", "dbo.Companies", "CompanyID", cascadeDelete: true);
        }
    }
}
