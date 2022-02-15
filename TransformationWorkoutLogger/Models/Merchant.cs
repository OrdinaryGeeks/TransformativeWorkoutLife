using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransformationWorkoutLife.Models
{
    public class Merchant
    {
        public int ID { get; set; }
        public virtual ICollection<Product> ProductPages { get; set; }

    }
}
