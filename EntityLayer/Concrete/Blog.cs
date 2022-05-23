using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogID{ get; set; }
        public string BlogFile { get; set; }
        public string BlogContent { get; set; }
        public string BlogThumbnailImage { get; set; }//Küçük resimler için kapak fotografları 
        public string BlogeImage { get; set; }
        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus{ get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
