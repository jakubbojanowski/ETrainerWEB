using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Trainer_WEB.Models
{
    public class Ingredient
    {
        public int id { set; get; }
        public int userId { set; get; }
        public string name { set; get; }
        public float portionWeight { set; get; }
        public float caloricityPerGram { set; get; }

    }
}
