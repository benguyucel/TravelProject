using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelProject.Models.Siniflar
{
    public class BlogYorum
    {
        public IEnumerable<Blog> Deger1 { get; set; }
        public IEnumerable<Yorumlar> Deger2 { get; set; }
        public IEnumerable<Blog> SonBloglar { get; set; }
        public IEnumerable<Yorumlar> SonYorumlar { get; set; }
    }
}