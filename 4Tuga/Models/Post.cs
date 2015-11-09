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
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public String Title { get; set; }

        public String Body { get; set; }

        public DateTime PublishDate { get; set; }

        //não faço a P***** do tipo que é imagem  ********************************************************
        public String Image { get; set; }
        //************************************************************************************************

        public int UserID { get; set; }


        public virtual ICollection<SubCategoryPost> SubCategories { get; set; }
        
        public virtual ICollection<PostTag> Tags { get; set; }

        public virtual ICollection<Comment>  Comments { get; set; }


        public virtual ApplicationUser User { get; set; }
   
    }
}