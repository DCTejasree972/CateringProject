namespace WebApplication14.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class image : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.cateringdetails", "image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.cateringdetails", "image");
        }
    }
}
