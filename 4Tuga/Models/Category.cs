using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _4Tuga.Models
{
    public class Category
    {
        public int ID { get; set; }
        public String Name { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; }
    }
}