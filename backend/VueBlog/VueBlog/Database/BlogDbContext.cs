using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VueBlog.Database
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class BlogDbContext : IdentityDbContext<IdentityUser>
    {
        public BlogDbContext() : base("Default")
        {

        }
    }
}