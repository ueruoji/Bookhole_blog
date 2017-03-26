using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bookhole_blog.Model
{
    public class Main
    {
        public List<Model.blog_type> Main_type { get; set; }
        public Model.blogs Main_hotblogs { get; set; }
        public List<Model.blogs> Main_tuiblogs { get; set; }
    }
}
