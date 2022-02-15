using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransformationWorkoutLogger.Models
{
    public class GuestOrder
    {
        public int ID { get; set; }
        public int GuestID { get; set; }
        public ICollection<GuestItemOrdered> ItemsOrdered { get; set; }
        public bool isPaid { get; set; }
    }
}
