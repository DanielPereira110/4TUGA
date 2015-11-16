using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _4Tuga.Models;

namespace _4Tuga.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<SubCategory> SubCategories { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}