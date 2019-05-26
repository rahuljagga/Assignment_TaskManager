namespace TaskManagerTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Secondrun : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TaskDBModels", newName: "Tasks");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Tasks", newName: "TaskDBModels");
        }
    }
}
