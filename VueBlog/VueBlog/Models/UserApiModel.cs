using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VueBlog.Models
{
    public class UserApiModel
    {
        public string UserName { get; set; }
        public string[] Roles { get; set; }
    }
}
