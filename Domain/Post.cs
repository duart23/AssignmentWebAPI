using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Post
{
    public int Id { get; set; }
    public User Owner { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }

    public Post(User Owner, string Title, string? Content)
    {
        this.Owner = Owner;
        this.Title = Title;
        this.Content = Content;
    }
    
    private Post(){}
    
}