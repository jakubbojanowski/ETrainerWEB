using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ETrainerWEB.Models.DTO
{
    public class ExerciseSchemaDTO
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Icon { set; get; }
        public string Properties { set; get; }
        [JsonIgnore]
        public User User { set; get; }
        [JsonIgnore]
        public ICollection<WorkoutSchemaExerciseSchema> WorkoutSchemasExercisesSchemas { get; set; }
    }
}