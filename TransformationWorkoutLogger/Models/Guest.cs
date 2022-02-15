using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransformationWorkoutLogger.Models
{
    public class Guest
    {

        public int ID { get; set; }
        public string EmailAddress { get; set; }

        public virtual ICollection<GuestOrder> Orders { get; set; }

        public virtual ICollection<GuestTrainingOrdered> Trainings { get; set; }
    }
}
