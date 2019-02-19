using Microsoft.AspNet.Identity.EntityFramework;
using Pixel_Art_Blog.Core;
using Pixel_Art_Blog.Core.Domain;
using Pixel_Art_Blog.Models;
using Pixel_Art_Blog.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Pixel_Art_Blog.Persistence
{
    public class BlogContext : IdentityDbContext<ApplicationUser>
    {
        public BlogContext()
            : base("name=BlogContext", throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Subscriber> Subscribers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new PostConfiguration());
            modelBuilder.Configurations.Add(new SubscriptionConfiguration());
        }

        public static BlogContext Create()
        {
            return new BlogContext();
        }
    }
}