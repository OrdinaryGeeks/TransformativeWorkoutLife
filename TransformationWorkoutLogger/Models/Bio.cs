using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransformationWorkoutLife.Models
{
    public class Bio
    {
        public int ID { get; set; }
        //Hold social media links for bio and footer
        public string FBLink { get; set; }
        public string IGLink { get; set; }
        public string SnapLink { get; set; }
        public string YoutubeLink { get; set; }
        public string Title { get; set; }

        //A blurb consists of an orientation, and optional media and text
        public virtual ICollection<BioBlurb> blurbs { get; set; }

        public int AdminID { get; set; }
    }
}
