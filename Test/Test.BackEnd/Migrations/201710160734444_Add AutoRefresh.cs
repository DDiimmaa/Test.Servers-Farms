namespace Test.BackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAutoRefresh : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Servers", "AutoRefreshTime", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Servers", "AutoRefreshTime");
        }
    }
}
