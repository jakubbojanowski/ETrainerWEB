using System.Text.Json.Serialization;

namespace ETrainerWEB.Models.DTO
{
    public class ExerciseDTO
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Icon { set; get; }
        public string Properties { set; get; }
        [JsonIgnore]
        public virtual Workout Workout { set; get; }
        public int CurrentWorkoutId { set; get; }
    }
}