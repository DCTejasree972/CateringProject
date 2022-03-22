namespace WebApplication14.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.categorydetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        section = c.String(),
                        check = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.cateringdetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        categID = c.Int(nullable: false),
                        name = c.String(),
                        people = c.Int(nullable: false),
                        items = c.String(),
                        cost = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.categorydetails", t => t.categID, cascadeDelete: true)
                .Index(t => t.categID);
            
            CreateTable(
                "dbo.deliverydetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        datetime = c.String(),
                        paymenttye = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.cateringdetails", "categID", "dbo.categorydetails");
            DropIndex("dbo.cateringdetails", new[] { "categID" });
            DropTable("dbo.deliverydetails");
            DropTable("dbo.cateringdetails");
            DropTable("dbo.categorydetails");
        }
    }
}
