namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterColumnAndMakeitRequiredInMembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false));
            DropColumn("dbo.MembershipTypes", "Membership");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "Membership", c => c.String());
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
