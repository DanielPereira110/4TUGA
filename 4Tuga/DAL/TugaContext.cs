using _4Tuga.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _4Tuga.DAL
{
    public class TugaContext 
    {
        public DbSet<File> Files { get; set; }
    }
}