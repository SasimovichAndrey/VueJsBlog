using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VueBlog.Database.Entities
{
    public class ArticleComment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Article")]
        public int ArticleId { get; set; }
        public string CommentatorName { get; set; }
        public string Content { get; set; }

        public BlogArticle Article { get; set; }
    }
}