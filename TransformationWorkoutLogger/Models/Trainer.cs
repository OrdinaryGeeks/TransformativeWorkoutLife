using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransformationWorkoutLife.Models
{
    public class Trainer
    {

        public int ID { get; set; }
        
        public virtual ICollection<Training> TrainingPages { get; set; }
 

    }
}
