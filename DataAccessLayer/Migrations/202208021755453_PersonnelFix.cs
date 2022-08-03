namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonnelFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Personnels", "Company_CompanyID", "dbo.Companies");
            DropIndex("dbo.Personnels", new[] { "Company_CompanyID" });
            RenameColumn(table: "dbo.Personnels", name: "Company_CompanyID", newName: "CompanyID");
            AlterColumn("dbo.Personnels", "CompanyID", c => c.Int(nullable: false));
            CreateIndex("dbo.Personnels", "CompanyID");
            AddForeignKey("dbo.Personnels", "CompanyID", "dbo.Companies", "CompanyID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personnels", "CompanyID", "dbo.Companies");
            DropIndex("dbo.Personnels", new[] { "CompanyID" });
            AlterColumn("dbo.Personnels", "CompanyID", c => c.Int());
            RenameColumn(table: "dbo.Personnels", name: "CompanyID", newName: "Company_CompanyID");
            CreateIndex("dbo.Personnels", "Company_CompanyID");
            AddForeignKey("dbo.Personnels", "Company_CompanyID", "dbo.Companies", "CompanyID");
        }
    }
}
