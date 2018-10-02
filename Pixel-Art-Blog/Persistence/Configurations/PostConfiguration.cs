using Pixel_Art_Blog.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Pixel_Art_Blog.Persistence.Configurations
{
    public class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(40);

            Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(500);

            Property(c => c.CategoryID)
                .IsRequired();
        }
    }
}