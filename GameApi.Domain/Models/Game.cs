namespace GameApi.Domain.Models;

public class Game (string title, string image, string description)
{
    public int Id { get; set; }
    
    public string Title { get; set; } = title;

    public string Image { get; set; } = image;

    public string Description { get; set; } = description;
}