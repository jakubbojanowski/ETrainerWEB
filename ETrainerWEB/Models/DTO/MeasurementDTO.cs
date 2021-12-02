using System.Text.Json.Serialization;

namespace ETrainerWEB.Models.DTO
{
    public class MeasurementDTO
    {
        public string Id { set; get; }
        public string Properties { set; get; }
        [JsonIgnore]
        public User User { get; set; }
    }
}