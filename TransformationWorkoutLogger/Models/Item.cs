using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransformationWorkoutLife.Models
{
    public class Item
    {

        public int ID { get; set; }

        public int ProductID { get; set; }

        //orientation = side by side, on top of , below,
        public Boolean MediaTop { get; set; }
        public Boolean MediaBottom { get; set; }
        public Boolean MediaLeft { get; set; }
        public Boolean MediaRight { get; set; }
        public string MediaLink { get; set; }
       public int Height { get; set; }
        public int Width { get; set; }
        public Boolean Image { get; set; }
        public Boolean Video { get; set; }
        public string Text { get; set; }
        public int Cost { get; set; }
        public string Description { get; set; }

        public int Quantity { get; set; }
        public string Name { get; set; }

    }
}
