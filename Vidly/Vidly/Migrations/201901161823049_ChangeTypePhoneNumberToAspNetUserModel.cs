namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTypePhoneNumberToAspNetUserModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Phone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Phone", c => c.Int(nullable: false));
        }
    }
}
