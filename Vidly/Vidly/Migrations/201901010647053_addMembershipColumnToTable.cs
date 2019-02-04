namespace Vidly.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	
	public partial class addMembershipColumnToTable : DbMigration
	{
		public override void Up()
		{
			AddColumn("dbo.MembershipTypes", "Membership", c => c.String());
			Sql("UPDATE [dbo].[MembershipTypes] SET Membership = 'Pay as You Go' WHERE SignUpFee=0");
			Sql("UPDATE [dbo].[MembershipTypes] SET Membership = 'Monthly' WHERE SignUpFee=30");
			Sql("UPDATE [dbo].[MembershipTypes] SET Membership = 'Quarterly' WHERE SignUpFee=90");
			Sql("UPDATE [dbo].[MembershipTypes] SET Membership = 'Yearly' WHERE SignUpFee=300");
		}
		
		public override void Down()
		{
			DropColumn("dbo.MembershipTypes", "Membership");
		}
	}
}
