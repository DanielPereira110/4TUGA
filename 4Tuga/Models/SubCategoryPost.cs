using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _4Tuga.Models
{
    public class SubCategoryPost
    {
        public int SubCategoryID { get; set; }
        public int PostID { get; set; }

        public virtual SubCategory SubCategory { get; set; }
        public virtual Post Post { get; set; }
    }
}