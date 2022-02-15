using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransformationWorkoutLogger.Models
{
    public class GuestTrainingOrdered
    {
        public int ID { get; set; }
        public int TrainingID { get; set; }
        public Schedule Schedule { get; set; }
        
    }
}
