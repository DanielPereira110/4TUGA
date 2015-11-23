using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _4Tuga.Models
{
    public class Post
    {
        public int ID { get; set; }
      
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public String Title { get; set; }
        [StringLength(5000, MinimumLength = 3)]
        public String Body { get; set; }
        public DateTime PublishDate { get; set; }
        // = DateTime.UtcNow;
        //não faço a P***** do tipo que é imagem  ********************************************************
        public String Image { get; set; }
        //************************************************************************************************

        public int SubCategoryID { get; set; }
        public int UserID { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Like> Like { get; set; }
        public virtual ICollection<SubCategory> SubCategory { get; set; }
        public virtual ICollection<Tag> Tag { get; set; }
        public virtual ICollection<Comment>  Comment { get; set; }



 
    }
}