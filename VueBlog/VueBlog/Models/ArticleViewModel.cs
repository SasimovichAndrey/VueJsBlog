using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VueBlog.Models
{
    public class ArticleViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string PreviewContent { get; set; }

        [Required]
        public string Content { get; set; }

        public IEnumerable<ArticleCommentViewModel> Comments { get; set; }
    }
}