namespace ChineseBridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(),
                        Name = c.String(),
                        CampusId = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campus", t => t.CampusId, cascadeDelete: true)
                .Index(t => t.CampusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "CampusId", "dbo.Campus");
            DropIndex("dbo.Books", new[] { "CampusId" });
            DropTable("dbo.Books");
        }
    }
}
