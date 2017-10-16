namespace Test.BackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Farms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Servers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EndPointURL = c.String(),
                        FarmId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Farms", t => t.FarmId, cascadeDelete: true)
                .Index(t => t.FarmId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Servers", "FarmId", "dbo.Farms");
            DropIndex("dbo.Servers", new[] { "FarmId" });
            DropTable("dbo.Servers");
            DropTable("dbo.Farms");
        }
    }
}
