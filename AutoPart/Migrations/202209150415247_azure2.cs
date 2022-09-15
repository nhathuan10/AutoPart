namespace AutoPart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class azure2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Phone", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Phone", c => c.String(nullable: false));
        }
    }
}
