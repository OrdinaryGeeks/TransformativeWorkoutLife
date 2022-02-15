using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransformationWorkoutLogger.Models
{
    public class GuestSchedule
    {
        public int ID { get; set; }
        public ICollection<Schedule> Schedule;
    }
}
