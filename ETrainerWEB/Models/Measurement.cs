using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ETrainerWEB.Models
{
    public class Measurement
    {
        [ForeignKey("User")]
        public string Id { set; get; }
        public string Properties { set; get; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}