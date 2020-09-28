namespace ChineseBridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClasstypeModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classtypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Color = c.String(),
                        Image = c.String(),
                        Teacher = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Classtypes");
        }
    }
}
