namespace TableauAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _init2 : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.AlexaSKills", newName: "AlexaSKill");
        }
        
        public override void Down()
        {
           // RenameTable(name: "dbo.AlexaSKill", newName: "AlexaSKills");
        }
    }
}
