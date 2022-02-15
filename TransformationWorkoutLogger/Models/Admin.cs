using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransformationWorkoutLife.Models
{
    public class Admin
    {

        public int ID { get; set; }
        public Bio Bio{ get; set; }
        public int MerchantID { get; set; }
        public int TrainerID { get; set; }

        public int GuestID { get; set; }
        public bool IsSuperAdmin { get; set; }





    }
}
