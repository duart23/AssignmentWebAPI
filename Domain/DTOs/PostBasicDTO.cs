namespace Domain.DTOs;

public class PostBasicDTO
{
    public string Username { get; }
    public string Title { get; }
    public string Content { get; }

    public PostBasicDTO(string username, string title, string content)
    {
        Username = username;
        Title = title;
        Content = content;
    }
}