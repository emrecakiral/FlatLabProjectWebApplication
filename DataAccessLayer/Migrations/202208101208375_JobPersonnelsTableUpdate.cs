namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobPersonnelsTableUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobPersonnels", "Job_JobID", "dbo.Jobs");
            DropForeignKey("dbo.JobPersonnels", "Personnel_PersonnelID", "dbo.Personnels");
            DropIndex("dbo.JobPersonnels", new[] { "Job_JobID" });
            DropIndex("dbo.JobPersonnels", new[] { "Personnel_PersonnelID" });
            DropTable("dbo.JobPersonnels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.JobPersonnels",
                c => new
                    {
                        Job_JobID = c.Int(nullable: false),
                        Personnel_PersonnelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Job_JobID, t.Personnel_PersonnelID });
            
            CreateIndex("dbo.JobPersonnels", "Personnel_PersonnelID");
            CreateIndex("dbo.JobPersonnels", "Job_JobID");
            AddForeignKey("dbo.JobPersonnels", "Personnel_PersonnelID", "dbo.Personnels", "PersonnelID", cascadeDelete: true);
            AddForeignKey("dbo.JobPersonnels", "Job_JobID", "dbo.Jobs", "JobID", cascadeDelete: true);
        }
    }
}
