namespace RoutingSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "AvailableDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "AvailableDate");
        }
    }
}
