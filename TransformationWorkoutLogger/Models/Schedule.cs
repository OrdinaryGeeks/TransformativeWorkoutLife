using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransformationWorkoutLogger.Models
{
    public class Schedule
    {
        public int ID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTIme { get; set; }
    }
}
