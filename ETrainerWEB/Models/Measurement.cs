using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ETrainerWEB.Models
{
    public class Measurement
    {
        public string Id { set; get; }
        public string Properties { set; get; }
        public User User { set; get; }
    }
}