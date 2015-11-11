using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _4Tuga.Models
{
    public class Comment
    {
        public int ID { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 3)]
        public String Body { get; set; }

        public DateTime PublishDate { get; set; }

        public int UserID { get; set; }
        public int PostID { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Post Post { get; set; }
    }
}