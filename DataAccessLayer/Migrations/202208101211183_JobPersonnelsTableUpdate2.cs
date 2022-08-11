namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobPersonnelsTableUpdate2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobPersonnels",
                c => new
                    {
                        JobPerssonnelsID = c.Int(nullable: false, identity: true),
                        JobID = c.Int(nullable: false),
                        PersonnelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobPerssonnelsID)
                .ForeignKey("dbo.Jobs", t => t.JobID)
                .ForeignKey("dbo.Personnels", t => t.PersonnelID)
                .Index(t => t.JobID)
                .Index(t => t.PersonnelID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobPersonnels", "PersonnelID", "dbo.Personnels");
            DropForeignKey("dbo.JobPersonnels", "JobID", "dbo.Jobs");
            DropIndex("dbo.JobPersonnels", new[] { "PersonnelID" });
            DropIndex("dbo.JobPersonnels", new[] { "JobID" });
            DropTable("dbo.JobPersonnels");
        }
    }
}
