namespace ChineseBridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReAddClassinCampus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassinCampus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CampusId = c.Int(nullable: false),
                        ClasstypeId = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campus", t => t.CampusId, cascadeDelete: true)
                .ForeignKey("dbo.Classtypes", t => t.ClasstypeId, cascadeDelete: true)
                .Index(t => t.CampusId)
                .Index(t => t.ClasstypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassinCampus", "ClasstypeId", "dbo.Classtypes");
            DropForeignKey("dbo.ClassinCampus", "CampusId", "dbo.Campus");
            DropIndex("dbo.ClassinCampus", new[] { "ClasstypeId" });
            DropIndex("dbo.ClassinCampus", new[] { "CampusId" });
            DropTable("dbo.ClassinCampus");
        }
    }
}
