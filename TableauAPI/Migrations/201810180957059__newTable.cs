namespace TableauAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _newTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalesSkill",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DashboardUrl = c.String(),
                        DashboardData = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SalesSkill");
        }
    }
}
