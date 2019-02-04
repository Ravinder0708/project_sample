namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBirthdateToMembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "BirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "BirthDate");
        }
    }
}
