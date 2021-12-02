using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ETrainerWEB.Models
{
    public class WorkoutSchema
    {
        public WorkoutSchema()
        {
            WorkoutSchemasExercisesSchemas = new List<WorkoutSchemaExerciseSchema>();
        }
        public int Id { set; get; }
        public string Name{ set; get; }
        public User User { set; get; }
        public ICollection<WorkoutSchemaExerciseSchema> WorkoutSchemasExercisesSchemas { get; set; }
    }
}