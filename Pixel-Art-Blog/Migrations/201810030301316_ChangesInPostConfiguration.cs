namespace Pixel_Art_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInPostConfiguration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Img", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Img", c => c.String());
        }
    }
}
