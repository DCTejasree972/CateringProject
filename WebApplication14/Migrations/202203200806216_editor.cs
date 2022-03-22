namespace WebApplication14.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.categorydetails", "check", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.categorydetails", "check");
        }
    }
}
