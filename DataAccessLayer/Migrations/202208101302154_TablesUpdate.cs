namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablesUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobPersonnels", "JobID", "dbo.Jobs");
            DropForeignKey("dbo.JobPersonnels", "PersonnelID", "dbo.Personnels");
            DropIndex("dbo.JobPersonnels", new[] { "JobID" });
            DropIndex("dbo.JobPersonnels", new[] { "PersonnelID" });
            CreateTable(
                "dbo.PersonnelJobs",
                c => new
                    {
                        Personnel_PersonnelID = c.Int(nullable: false),
                        Job_JobID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Personnel_PersonnelID, t.Job_JobID })
                .ForeignKey("dbo.Personnels", t => t.Personnel_PersonnelID, cascadeDelete: true)
                .ForeignKey("dbo.Jobs", t => t.Job_JobID, cascadeDelete: true)
                .Index(t => t.Personnel_PersonnelID)
                .Index(t => t.Job_JobID);
            
            DropTable("dbo.JobPersonnels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.JobPersonnels",
                c => new
                    {
                        JobPerssonnelsID = c.Int(nullable: false, identity: true),
                        JobID = c.Int(nullable: false),
                        PersonnelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobPerssonnelsID);
            
            DropForeignKey("dbo.PersonnelJobs", "Job_JobID", "dbo.Jobs");
            DropForeignKey("dbo.PersonnelJobs", "Personnel_PersonnelID", "dbo.Personnels");
            DropIndex("dbo.PersonnelJobs", new[] { "Job_JobID" });
            DropIndex("dbo.PersonnelJobs", new[] { "Personnel_PersonnelID" });
            DropTable("dbo.PersonnelJobs");
            CreateIndex("dbo.JobPersonnels", "PersonnelID");
            CreateIndex("dbo.JobPersonnels", "JobID");
            AddForeignKey("dbo.JobPersonnels", "PersonnelID", "dbo.Personnels", "PersonnelID");
            AddForeignKey("dbo.JobPersonnels", "JobID", "dbo.Jobs", "JobID");
        }
    }
}
