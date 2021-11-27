using System.Collections.Generic;

namespace ETrainerWEB.Models.DTO
{
    public class ExerciseTypeDTO
    {
        //public int Id { set; get; }
        public string Name { set; get; }
        public Category Category { set; get; }
        public string Icon { set; get; }
        public string Properties { set; get; }
        //public ICollection<Exercise> Exercises { get; set; }
        //public ICollection<ExerciseSchema> ExerciseSchemas { get; set; }
    }
}