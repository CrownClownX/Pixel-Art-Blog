namespace Pixel_Art_Blog.Migrations
{
    using Pixel_Art_Blog.Core.Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Pixel_Art_Blog.Persistence.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Pixel_Art_Blog.Persistence.BlogContext context)
        {
            //context.Categories.AddOrUpdate(c => c.ID,
            //    new Category {
            //        Name = "Tutorials",
            //        Description = @"This door will take you to the world of possibilities. 
            //                        Only things you need to go there is brave and patient. 
            //                        Seriously, even your clothes should stay outside." },
            //    new Category {
            //        Name = "Thoughts",
            //        Description = @"If you really want to see some weird wiggly-biggly just 
            //                        jump in here. You're not gonna regret it. At least,not now. 
            //                        But who knows what will be tomorrow."
            //    },
            //    new Category {
            //        Name = "Lifestyle",
            //        Description = @"Spooky nerd giving advices about life. Thats what you 
            //                        find inisde. Pls, don't go in there. After you dive 
            //                        into this shit you will never recover to normal."
            //    }
            //    );
        }
    }
}
