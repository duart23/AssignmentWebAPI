namespace Domain.DTOs;

public class PostCreationDTO
{
    public string UserName { get; }
    public string Title { get; }
    public string Content { get; }
    public int Id { get; }
  

    public PostCreationDTO(string userName, string title, string content)
    {
        UserName = userName;
        Title = title;
        Content = content;
    }
}