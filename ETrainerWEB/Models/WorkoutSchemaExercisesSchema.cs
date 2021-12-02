using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ETrainerWEB.Models
{
    public class WorkoutSchemaExerciseSchema
    {
        public int Id { set; get; }
        [JsonIgnore]
        public WorkoutSchema WorkoutSchema { set; get; }
        [NotMapped]
        public int CurrentWorkoutSchemaId { set; get; }
        [JsonIgnore]
        public ExerciseSchema ExerciseSchema { set; get; }
        [NotMapped]
        public int CurrentExerciseSchemaId { set; get; }
    }
}