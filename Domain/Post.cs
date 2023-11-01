namespace Domain;

public class Post
{
    public int Id { get; set; }
    public User Owner { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public Post(User Owner, string Title, string? Content)
    {
        this.Owner = Owner;
        this.Title = Title;
        this.Content = Content;
    }
    
}