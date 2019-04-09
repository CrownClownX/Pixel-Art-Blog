namespace Pixel_Art_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bc0b2915-2293-46eb-b5fd-31371968b74f', N'admin@pixelart.com', 0, N'APYRus4hOuf7fLZ0wcBTx1gc+u8zeCdw2YWnHn9AepuK1Tj3I9Vg5dvqoJ27CnXLcw==', N'73fc0667-65ba-45a0-bc0c-301f46a9fb5f', NULL, 0, 0, NULL, 1, 0, N'admin@pixelart.com')");
        }
        
        public override void Down()
        {
        }
    }
}
