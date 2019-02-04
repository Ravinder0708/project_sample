namespace Vidly.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	
	public partial class SeedUsers : DbMigration
	{
		public override void Up()
		{
			Sql(@"INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1d32bc6c-2f1a-4c89-887c-7b417367b5b4', N'CanManageMovies')
				GO
				INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'026a4e9d-c928-49d0-abec-d710eea260f6', N'admin@vidly.com', 0, N'ANuWgNW0+nxwio2L+4+apsyIJIo7VwjWd9ljLf0T2ycgM5LNd/aIM3db73NVBK11iQ==', N'4aea1cfe-ad69-414f-9cae-70c27fe1d014', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
				GO
				INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ec8beb05-465f-4e17-88cf-60743c9ccde6', N'ravi@gmail.com', 0, N'ALbM8UO4Z3h1PyVJygGA0TDVe0E7sygp7W+vcl7mQ1aEeIP9MK9zXXtcFxVMpbidMA==', N'f95897b1-3cac-42bd-8d09-3a39f7423049', NULL, 0, 0, NULL, 1, 0, N'ravi@gmail.com')
				GO
				INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'026a4e9d-c928-49d0-abec-d710eea260f6', N'1d32bc6c-2f1a-4c89-887c-7b417367b5b4')
				GO");
		}
		
		public override void Down()
		{

		}
	}
}
