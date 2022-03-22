namespace WebApplication14.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.categorydetails", "type", c => c.String());
            DropColumn("dbo.categorydetails", "check");
        }
        
        public override void Down()
        {
            AddColumn("dbo.categorydetails", "check", c => c.Boolean(nullable: false));
            DropColumn("dbo.categorydetails", "type");
        }
    }
}
