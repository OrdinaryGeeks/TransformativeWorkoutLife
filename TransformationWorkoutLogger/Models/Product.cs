using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransformationWorkoutLife.Models
{
    public class Product
    {
        //page for displaying items

        public int ID { get; set; }
        public Blurb Blurb { get; set; }
   
        public string Title { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        public int MerchantID { get; set; }
    }
}
