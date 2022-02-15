using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransformationWorkoutLogger.Models;

namespace TransformationWorkoutLife.Models
{
    public class Training
    {

        public int ID { get; set; }
        public Blurb Blurb { get; set; }
        public string Title { get; set; }

        public ICollection<Schedule> TrainingSchedule { get; set; }
        
        public Schedule LengthOfProgram { get; set; }
        public virtual ICollection<TrainingVideo> TrainingVideos { get; set; }
        public int TrainerID { get; set; }
    }
}
