using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _4Tuga.Models
{
    public class Category
    {
        public int ID { get; set; }
      

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public String Name { get; set; }
        public int ParentID { get; set; }

        public ICollection<Category> SubCategories { get; set; }
        public virtual Category Parent { get; set; }
        public virtual ICollection<Post> Post { get; set; }
    }
}