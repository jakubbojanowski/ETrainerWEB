using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ETrainerWEB.Models
{
    public class WorkoutSchemaExerciseSchema
    {
        public int Id { set; get; }
        public WorkoutSchema WorkoutSchema { set; get; }
        public int WorkoutSchemaId { set; get; }
        public ExerciseSchema ExerciseSchema { set; get; }
        public int ExerciseSchemaId { set; get; }
    }
}