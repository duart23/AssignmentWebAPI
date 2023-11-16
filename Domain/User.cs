using System.Text.Json.Serialization;

namespace Domain;

public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string password { get; set; }
    [JsonIgnore]
    public ICollection<Post> Posts { get; set; }
    
}