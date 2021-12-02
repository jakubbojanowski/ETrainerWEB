using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ETrainerWEB.Models
{
    public class WorkoutSchema
    { 
        public int Id { set; get; }
        public string Name{ set; get; }
        [JsonIgnore]
        public User User { set; get; }
        [JsonIgnore]
        public ICollection<WorkoutSchemaExerciseSchema> WorkoutSchemasExercisesSchemas { get; set; }
    }
}