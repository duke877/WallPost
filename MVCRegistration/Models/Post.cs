using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCRegistration.Models
{
    public class Post
    {
        public Post()
        {
            this.PostComments = new HashSet<PostComment>();
        }
        [Key]
        public int PostId { get; set; }
        public string Message { get; set; }
        public int? PostedBy { get; set; }
        public System.DateTime PostedDate { get; set; }
        public virtual ICollection<PostComment> PostComments { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}