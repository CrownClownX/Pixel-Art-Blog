namespace Pixel_Art_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfigurationOfPostTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Posts", "Description", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Description", c => c.String());
            AlterColumn("dbo.Posts", "Title", c => c.String());
        }
    }
}
