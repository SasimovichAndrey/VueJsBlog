using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VueBlog.Models
{
    public class ArticleCommentViewModel
    {
        public int? Id { get; set; }

        [Required]
        public int? ArticleId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string CommentatorName { get; set; }
    }
}