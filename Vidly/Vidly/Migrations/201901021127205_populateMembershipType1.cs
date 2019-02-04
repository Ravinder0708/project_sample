namespace Vidly.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	
	public partial class populateMembershipType1 : DbMigration
	{
		public override void Up()
		{
			Sql("UPDATE [dbo].[MembershipTypes] SET Name = 'Pay as You Go' WHERE SignUpFee=0");
			Sql("UPDATE [dbo].[MembershipTypes] SET Name = 'Monthly' WHERE SignUpFee=30");
			Sql("UPDATE [dbo].[MembershipTypes] SET Name = 'Quarterly' WHERE SignUpFee=90");
			Sql("UPDATE [dbo].[MembershipTypes] SET Name = 'Yearly' WHERE SignUpFee=300");
		}
		
		public override void Down()
		{
		}
	}
}
