using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VueBlog.Database.Entities
{
    public class BlogArticle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string PreviewContent { get; set; }
        public string Content { get; set; }

        [InverseProperty("Article")]
        public ICollection<ArticleComment> Comments { get; set; }
    }
}