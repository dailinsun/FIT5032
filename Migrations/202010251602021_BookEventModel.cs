namespace ChineseBridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookEventModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassinCampusId = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.ClassinCampus", t => t.ClassinCampusId, cascadeDelete: true)
                .Index(t => t.ClassinCampusId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookEvents", "ClassinCampusId", "dbo.ClassinCampus");
            DropForeignKey("dbo.BookEvents", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.BookEvents", new[] { "ApplicationUserId" });
            DropIndex("dbo.BookEvents", new[] { "ClassinCampusId" });
            DropTable("dbo.BookEvents");
        }
    }
}
