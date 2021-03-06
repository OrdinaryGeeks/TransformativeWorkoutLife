using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransformationWorkoutLife.Models
{
    public class Blurb
    {
        public int ID { get; set; }
        //orientation = side by side, on top of , below,
        public Boolean MediaTop { get; set; }
        public Boolean MediaBottom { get; set; }
        public Boolean MediaLeft { get; set; }
        public Boolean MediaRight { get; set; }
        public string MediaLink { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public Boolean Media { get; set; }
        public Boolean Video { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }

        public DateTime PostedDate { get; set; }
    }
}
