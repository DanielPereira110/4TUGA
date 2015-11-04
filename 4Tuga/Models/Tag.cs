using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _4Tuga.Models
{
    public class Tag
    {
        public int ID { get; set; }
        public String Nome { get; set; }

        public virtual ICollection<PostTag> Post { get; set; }
    }
}