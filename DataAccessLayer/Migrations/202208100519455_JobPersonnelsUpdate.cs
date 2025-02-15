﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobPersonnelsUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 20),
                        Password = c.String(maxLength: 16),
                        MailAddress = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyID = c.Int(nullable: false, identity: true),
                        CompanyTitle = c.String(maxLength: 100),
                        Phone = c.String(),
                        Address = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.CompanyID);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        ManagerID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        SurName = c.String(maxLength: 50),
                        Image = c.String(maxLength: 100),
                        UserName = c.String(maxLength: 20),
                        Password = c.String(maxLength: 16),
                        MailAddress = c.String(),
                        Role = c.String(),
                        CompanyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ManagerID)
                .ForeignKey("dbo.Companies", t => t.CompanyID)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Personnels",
                c => new
                    {
                        PersonnelID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        SurName = c.String(maxLength: 50),
                        Image = c.String(maxLength: 250),
                        UserName = c.String(maxLength: 20),
                        Password = c.String(maxLength: 16),
                        MailAddress = c.String(),
                        Role = c.String(),
                        ManagerID = c.Int(nullable: false),
                        CompanyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonnelID)
                .ForeignKey("dbo.Companies", t => t.CompanyID)
                .ForeignKey("dbo.Managers", t => t.ManagerID)
                .Index(t => t.ManagerID)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobID = c.Int(nullable: false, identity: true),
                        Priority = c.Byte(nullable: false),
                        Title = c.String(maxLength: 50),
                        Contents = c.String(maxLength: 1000),
                        CompletionDate = c.DateTime(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Document = c.String(maxLength: 100),
                        Status = c.Boolean(nullable: false),
                        ManagerID = c.Int(),
                    })
                .PrimaryKey(t => t.JobID)
                .ForeignKey("dbo.Managers", t => t.ManagerID)
                .Index(t => t.ManagerID);
            
            CreateTable(
                "dbo.Mails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SenderMail = c.String(maxLength: 50),
                        ReceiverMail = c.String(maxLength: 50),
                        Subject = c.String(maxLength: 100),
                        Message = c.String(maxLength: 2000),
                        Date = c.DateTime(nullable: false),
                        Importance = c.String(),
                        Document = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.JobPersonnels",
                c => new
                    {
                        Job_JobID = c.Int(nullable: false),
                        Personnel_PersonnelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Job_JobID, t.Personnel_PersonnelID })
                .ForeignKey("dbo.Jobs", t => t.Job_JobID, cascadeDelete: true)
                .ForeignKey("dbo.Personnels", t => t.Personnel_PersonnelID, cascadeDelete: true)
                .Index(t => t.Job_JobID)
                .Index(t => t.Personnel_PersonnelID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personnels", "ManagerID", "dbo.Managers");
            DropForeignKey("dbo.JobPersonnels", "Personnel_PersonnelID", "dbo.Personnels");
            DropForeignKey("dbo.JobPersonnels", "Job_JobID", "dbo.Jobs");
            DropForeignKey("dbo.Jobs", "ManagerID", "dbo.Managers");
            DropForeignKey("dbo.Personnels", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Managers", "CompanyID", "dbo.Companies");
            DropIndex("dbo.JobPersonnels", new[] { "Personnel_PersonnelID" });
            DropIndex("dbo.JobPersonnels", new[] { "Job_JobID" });
            DropIndex("dbo.Jobs", new[] { "ManagerID" });
            DropIndex("dbo.Personnels", new[] { "CompanyID" });
            DropIndex("dbo.Personnels", new[] { "ManagerID" });
            DropIndex("dbo.Managers", new[] { "CompanyID" });
            DropTable("dbo.JobPersonnels");
            DropTable("dbo.Mails");
            DropTable("dbo.Jobs");
            DropTable("dbo.Personnels");
            DropTable("dbo.Managers");
            DropTable("dbo.Companies");
            DropTable("dbo.Admins");
        }
    }
}
