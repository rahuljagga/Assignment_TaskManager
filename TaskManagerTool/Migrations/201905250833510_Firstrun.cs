namespace TaskManagerTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Firstrun : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskDBModels",
                c => new
                    {
                        TaskID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Priority = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        EstimatedCost = c.Double(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.TaskID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TaskDBModels");
        }
    }
}
