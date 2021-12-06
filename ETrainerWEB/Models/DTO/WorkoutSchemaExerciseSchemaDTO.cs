using System.Text.Json.Serialization;

namespace ETrainerWEB.Models.DTO
{
    public class WorkoutSchemaExerciseSchemaDTO
    {
        public int Id { set; get; }
        [JsonIgnore]
        public WorkoutSchema WorkoutSchema { set; get; }
        public int CurrentWorkoutSchemaId { set; get; }
        [JsonIgnore]
        public ExerciseSchema ExerciseSchema { set; get; }
        public int CurrentExerciseSchemaId { set; get; }
        
    }
}