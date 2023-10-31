namespace Domain.DTOs;

public class PostCreationDTO
{
    public int OwnerId { get; }
    public string Title { get; }
    public string Content { get; }

    public PostCreationDTO(int ownerId, string title, string content)
    {
        OwnerId = ownerId;
        Title = title;
        Content = content;
    }
}