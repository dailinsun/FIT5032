namespace ChineseBridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveClassinCampus : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClassinCampus", "CampusId", "dbo.Campus");
            DropForeignKey("dbo.ClassinCampus", "ClasstypeId", "dbo.Classtypes");
            DropIndex("dbo.ClassinCampus", new[] { "CampusId" });
            DropIndex("dbo.ClassinCampus", new[] { "ClasstypeId" });
            AlterColumn("dbo.Classtypes", "Color", c => c.String(maxLength: 200));
            DropTable("dbo.ClassinCampus");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Classtypes", "Color", c => c.String());
            CreateIndex("dbo.ClassinCampus", "ClasstypeId");
            CreateIndex("dbo.ClassinCampus", "CampusId");
            AddForeignKey("dbo.ClassinCampus", "ClasstypeId", "dbo.Classtypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClassinCampus", "CampusId", "dbo.Campus", "Id", cascadeDelete: true);
        }
    }
}
