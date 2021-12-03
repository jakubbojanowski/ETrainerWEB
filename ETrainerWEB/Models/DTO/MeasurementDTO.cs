using System;
using System.Text.Json.Serialization;

namespace ETrainerWEB.Models.DTO
{
    public class MeasurementDTO
    {
        public int Id { set; get; }
        public string Properties { set; get; }
        public DateTime Date { set; get; }
        [JsonIgnore]
        public User User { get; set; }
    }
}