using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace flappyBird_Server.Models
{
    public class Score
    {
        public int Id { get; set; }

        public string Pseudo { get; set; }

        public string date { get; set; }

        public string timeInSeconds { get; set; }

        public int scoreValue { get; set; }

        public bool isPublic { get; set; }

        [JsonIgnore]
        public virtual User? User { get; set; }
    }
}
