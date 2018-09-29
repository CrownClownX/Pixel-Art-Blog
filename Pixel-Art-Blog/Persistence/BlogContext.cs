﻿using Pixel_Art_Blog.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Pixel_Art_Blog.Persistence
{
    public class BlogContext : DbContext
    {
        public BlogContext()
            : base("name=BlogContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}