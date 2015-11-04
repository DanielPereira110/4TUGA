using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _4Tuga.Models
{
    public class SubCategory
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }
        public ICollection<SubCategoryPost> SubCategoryPosts { get; set; }
    }
}
