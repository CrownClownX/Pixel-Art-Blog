namespace Pixel_Art_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c21a2d6c-094c-47d8-895c-72ea3798e109', N'admin@blog.com', 0, N'AD23/KGMBCsdRPVqHj4ZCs4QtIwVOXPNbL5hKSbQn0QuWV1LLg8iYPBj7fRE9dBZrg==', N'738c6dde-7a99-4505-b310-ec84781f2277', NULL, 0, 0, NULL, 1, 0, N'admin@blog.com')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
