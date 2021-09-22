using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Trainer_WEB.Models
{
    public class ExerciseSchema
    {
        public int id { set; get; }
        public int userId { set; get; }
        public int typeId { set; get; }
        public string properties { set; get; }

    }
}
