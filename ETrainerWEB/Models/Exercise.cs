using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Trainer_WEB.Models
{
    public class Exercise
    {
        public int id { set; get; }
        public string name { set; get; }
        public int workoutId { set; get; }
        public int typeId { set; get; }
        public string properties { set; get; }

    }
}
