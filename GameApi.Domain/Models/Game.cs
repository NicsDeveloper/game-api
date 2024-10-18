namespace GameApi.Domain.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public List<string> Plataforms { get; set; }
        public string Subtitle { get; set; }

        public Game(string title, string image, string description, int rating, List<string> plataforms, string subtitle)
        {
            Title = title;
            Image = image;
            Description = description;
            Rating = rating;
            Plataforms = plataforms;
            Subtitle = subtitle;
        }
    }
}