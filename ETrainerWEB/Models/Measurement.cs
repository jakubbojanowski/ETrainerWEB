using System.ComponentModel.DataAnnotations.Schema;

namespace ETrainerWEB.Models
{
    public class Measurement
    {
        [ForeignKey("User")]
        public string Id { set; get; }
        public string Properties { set; get; }
        public virtual User User { get; set; }
    }
}