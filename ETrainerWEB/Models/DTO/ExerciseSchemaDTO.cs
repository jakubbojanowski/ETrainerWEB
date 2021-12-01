using System.Collections.Generic;

namespace ETrainerWEB.Models.DTO
{
    public class ExerciseSchemaDTO
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Icon { set; get; }
        public string UserId { set; get; }
        public int ExerciseTypeId { set; get; }
        public string Properties { set; get; }
        //public ICollection<WorkoutSchemaExerciseSchema> WorkoutSchemasExercisesSchemas { get; set; }
    }
}