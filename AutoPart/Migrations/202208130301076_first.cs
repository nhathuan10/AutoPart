namespace AutoPart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class first : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "Account");
        }

        public override void Down()
        {
            AddColumn("dbo.Customers", "Account", c => c.String(nullable: false));
        }
    }
}
