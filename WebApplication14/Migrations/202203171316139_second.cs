namespace WebApplication14.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.categorydetails", "categID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.categorydetails", "categID");
        }
    }
}
