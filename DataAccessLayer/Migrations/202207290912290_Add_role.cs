namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_role : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Role", c => c.String());
            AddColumn("dbo.Managers", "Role", c => c.String());
            AddColumn("dbo.Personnels", "Role", c => c.String());
            DropColumn("dbo.Admins", "AdminRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
            DropColumn("dbo.Personnels", "Role");
            DropColumn("dbo.Managers", "Role");
            DropColumn("dbo.Admins", "Role");
        }
    }
}
