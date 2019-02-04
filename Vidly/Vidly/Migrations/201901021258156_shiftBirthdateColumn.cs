namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shiftBirthdateColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthDate", c => c.DateTime());
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.MembershipTypes", "BirthDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "BirthDate", c => c.DateTime());
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Customers", "BirthDate");
        }
    }
}
