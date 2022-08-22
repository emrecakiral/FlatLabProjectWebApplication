namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAdmin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Name", c => c.String());
            AddColumn("dbo.Admins", "SurName", c => c.String());
            AddColumn("dbo.Admins", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "Image");
            DropColumn("dbo.Admins", "SurName");
            DropColumn("dbo.Admins", "Name");
        }
    }
}
