namespace TableauAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlexaSkills",
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
            DropTable("dbo.AlexaSkills");
        }
    }
}
