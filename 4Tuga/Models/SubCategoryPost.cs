using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _4Tuga.Models
{
    public class SubCategoryPost
    {
        public int ID { get; set; }
        public int SubCategoryID { get; set; }
        public int PostID { get; set; }

        public virtual SubCategory SubCategory { get; set; }
        public virtual Post Post { get; set; }
    }
}