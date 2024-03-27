using System.ComponentModel.DataAnnotations;

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

    }
}
