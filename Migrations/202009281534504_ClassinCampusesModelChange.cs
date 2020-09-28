namespace ChineseBridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassinCampusesModelChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClassinCampus", "Campus_Id", "dbo.Campus");
            DropForeignKey("dbo.ClassinCampus", "Classtype_Id", "dbo.Classtypes");
            DropIndex("dbo.ClassinCampus", new[] { "Campus_Id" });
            DropIndex("dbo.ClassinCampus", new[] { "Classtype_Id" });
            RenameColumn(table: "dbo.ClassinCampus", name: "Campus_Id", newName: "CampusId");
            RenameColumn(table: "dbo.ClassinCampus", name: "Classtype_Id", newName: "ClasstypeId");
            AlterColumn("dbo.ClassinCampus", "CampusId", c => c.Int(nullable: false));
            AlterColumn("dbo.ClassinCampus", "ClasstypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.ClassinCampus", "CampusId");
            CreateIndex("dbo.ClassinCampus", "ClasstypeId");
            AddForeignKey("dbo.ClassinCampus", "CampusId", "dbo.Campus", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClassinCampus", "ClasstypeId", "dbo.Classtypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassinCampus", "ClasstypeId", "dbo.Classtypes");
            DropForeignKey("dbo.ClassinCampus", "CampusId", "dbo.Campus");
            DropIndex("dbo.ClassinCampus", new[] { "ClasstypeId" });
            DropIndex("dbo.ClassinCampus", new[] { "CampusId" });
            AlterColumn("dbo.ClassinCampus", "ClasstypeId", c => c.Int());
            AlterColumn("dbo.ClassinCampus", "CampusId", c => c.Int());
            RenameColumn(table: "dbo.ClassinCampus", name: "ClasstypeId", newName: "Classtype_Id");
            RenameColumn(table: "dbo.ClassinCampus", name: "CampusId", newName: "Campus_Id");
            CreateIndex("dbo.ClassinCampus", "Classtype_Id");
            CreateIndex("dbo.ClassinCampus", "Campus_Id");
            AddForeignKey("dbo.ClassinCampus", "Classtype_Id", "dbo.Classtypes", "Id");
            AddForeignKey("dbo.ClassinCampus", "Campus_Id", "dbo.Campus", "Id");
        }
    }
}
