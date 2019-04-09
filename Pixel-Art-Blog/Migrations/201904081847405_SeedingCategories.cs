namespace Pixel_Art_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingCategories : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO CATEGORIES(NAME, Description) VALUES('Tutorials', 'This door will take you to the world of possibilities. Only things you need to go there is brave and patient. Seriously, even your clothes should stay outside.')");
            Sql(@"INSERT INTO CATEGORIES(NAME, Description) VALUES('Thoughts', 'If you really want to see some weird wiggly-biggly just jump in here. You''re not gonna regret it. At least not now. But who knows what will be tomorrow.')");
            Sql(@"INSERT INTO CATEGORIES(NAME, Description) VALUES('Lifestyle', 'Spooky nerd giving advices about life. Thats what you find inside. Pls, don''t go in there. After you dive into this shit you will never recover back to normal.')");
        }
        
        public override void Down()
        {
        }
    }
}
