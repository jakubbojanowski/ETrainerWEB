namespace ETrainerWEB.Models
{
    public class Exercise
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Icon { set; get; }
        public int WorkoutId { set; get; }
        public int TypeId { set; get; }
        public string Properties { set; get; }

    }
}
