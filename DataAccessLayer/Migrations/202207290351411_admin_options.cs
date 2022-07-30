namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class admin_options : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
            DropColumn("dbo.Admins", "Name");
            DropColumn("dbo.Admins", "SurName");
            DropColumn("dbo.Admins", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "Image", c => c.String(maxLength: 100));
            AddColumn("dbo.Admins", "SurName", c => c.String(maxLength: 50));
            AddColumn("dbo.Admins", "Name", c => c.String(maxLength: 50));
            DropColumn("dbo.Admins", "AdminRole");
        }
    }
}
