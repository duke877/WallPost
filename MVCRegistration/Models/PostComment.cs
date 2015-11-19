using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCRegistration.Models
{
    public class PostComment
    {
        [Key]
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string Message { get; set; }
        public int? CommentedBy { get; set; }
        public System.DateTime CommentedDate { get; set; }
        public virtual Post Post { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}