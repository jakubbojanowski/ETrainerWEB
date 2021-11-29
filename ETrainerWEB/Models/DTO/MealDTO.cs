using System;
using System.Collections.Generic;

namespace ETrainerWEB.Models.DTO
{
    public class MealDTO
    {
        public int Id { set; get; }
        public string UserId { set; get; }
        public DateTime Date { set; get; }
        public string Name { set; get; }
        //public ICollection<MealsDishesDTO> MealsDishes { get; set; }
    }
}