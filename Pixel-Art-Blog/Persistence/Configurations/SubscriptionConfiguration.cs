using Pixel_Art_Blog.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Pixel_Art_Blog.Persistence.Configurations
{
    public class SubscriptionConfiguration : EntityTypeConfiguration<Subscriber>
    {
        public SubscriptionConfiguration()
        {
            Property(c => c.Email)
                .IsRequired();

            Property(c => c.Name)
                .IsRequired();
        }
    }
}