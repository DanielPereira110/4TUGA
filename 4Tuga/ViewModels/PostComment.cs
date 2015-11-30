using _4Tuga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _4Tuga.ViewModels
{
    public class PostComment
    {
        public IEnumerable<Comment> Comments { get; set; }
        public Comment Comment { get; set; }
        public Post Posts { get; set; }
    }
}