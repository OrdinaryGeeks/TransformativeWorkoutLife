using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransformationWorkoutLife.Models
{
    public class TrainingVideo
    {
        public int ID { get; set; }

        public string Title { get; set; }
        public Boolean Back { get; set; }
        public Boolean Chest { get; set; }
        public Boolean Biceps { get; set; }
        public Boolean Triceps { get; set; }
        public Boolean Shoulders { get; set; }
        public Boolean ForeArms { get; set; }

        public Boolean Abs { get; set; }
        public Boolean Buttocks { get; set; }
        public Boolean Quadriceps { get; set; }
        public Boolean Hamstrings { get; set; }
        public Boolean Calves { get; set; }
        public Boolean MediaTop { get; set; }
        public Boolean MediaBottom { get; set; }
        public Boolean MediaLeft { get; set; }
        public Boolean MediaRight { get; set; }
        public string MediaLink { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public string Text { get; set; }
        public int Cost { get; set; }
        public string Description { get; set; }
    }
}
