namespace ChineseBridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassinCampusModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassinCampus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        Campus_Id = c.Int(),
                        Classtype_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campus", t => t.Campus_Id)
                .ForeignKey("dbo.Classtypes", t => t.Classtype_Id)
                .Index(t => t.Campus_Id)
                .Index(t => t.Classtype_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassinCampus", "Classtype_Id", "dbo.Classtypes");
            DropForeignKey("dbo.ClassinCampus", "Campus_Id", "dbo.Campus");
            DropIndex("dbo.ClassinCampus", new[] { "Classtype_Id" });
            DropIndex("dbo.ClassinCampus", new[] { "Campus_Id" });
            DropTable("dbo.ClassinCampus");
        }
    }
}
