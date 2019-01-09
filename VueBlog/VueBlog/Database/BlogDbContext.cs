using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using VueBlog.Database.Entities;

namespace VueBlog.Database
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class BlogDbContext : IdentityDbContext<IdentityUser>
    {
        public BlogDbContext() : base("Default")
        {
            this.Configuration.LazyLoadingEnabled = false;

#if DEBUG
            this.Database.Log = (message) => Debug.WriteLine(message);
#endif
        }

        public DbSet<BlogArticle> Articles { get; set; }
        public DbSet<ArticleComment> ArticleComments { get; set; }
    }
}
