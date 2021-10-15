using System.Collections.Generic;

namespace ETrainerWEB.Models
{
    public class WorkoutSchema
    {
        public WorkoutSchema()
        {
            WorkoutSchemasExercisesSchemas = new List<WorkoutSchemasExercisesSchemas>();
        }
        public int Id { set; get; }
        public string Name{ set; get; }
        public int UserId { set; get; }
        public virtual ICollection<WorkoutSchemasExercisesSchemas> WorkoutSchemasExercisesSchemas { get; set; }
    }
}