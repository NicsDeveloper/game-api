namespace GameApi.Domain.Models
{
    public class Game(string title, string image, string description)
    {
        public int Id { get; init; }
        public string Title { get; init; } = title;
        public string Image { get; init; } = image;
        public string Description { get; init; } = description;
    }
}