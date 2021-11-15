using System.Collections.Generic;

namespace ETrainerWEB.Models.DTO
{
    public class WorkoutSchemaDTO
    {
        public int Id { set; get; }
        public string Name{ set; get; }
        public string UserId { set; get; }
        public ICollection<WorkoutSchemasExercisesSchemas> WorkoutSchemasExercisesSchemas { get; set; }
    }
}