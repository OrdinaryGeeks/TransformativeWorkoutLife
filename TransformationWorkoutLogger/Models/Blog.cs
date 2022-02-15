using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransformationWorkoutLife.Models
{
    public class Blog
    {
        public int ID { get; set; }

        public string Title { get; set; }
        public string TitleHeader { get; set; }
        public virtual ICollection<BlogBlurb> Blurbs { get; set; }

        public int AdminID { get; set; }
    }
}
