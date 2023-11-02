using Application.DAOInterfaces;
using Domain;
using Domain.DTOs;

namespace FileData.DAOs;

public class PostFileDAO : IPostDAO
{
    private readonly FileContext context;
    
        public PostFileDAO(FileContext context)
        {
            this.context = context;
        }
    public Task<Post> CreateAsync(Post post)
        {
            int id = 1;
            if (context.Posts.Any())
            {
                id = context.Posts.Max(t => t.Id);
                id++;
            }
    
            post.Id = id;
            
            context.Posts.Add(post);
            context.SaveChanges();
    
            return Task.FromResult(post);
        }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParameteresDTO searchParams)
    {
        IEnumerable<Post> result = context.Posts.AsEnumerable();

        if (!string.IsNullOrEmpty(searchParams.UserName))
        {
            // we know username is unique, so just fetch the first
            result = context.Posts.Where(todo =>
                todo.Owner.UserName.Equals(searchParams.UserName, StringComparison.OrdinalIgnoreCase));
        }

        if (searchParams.UserName != null)
        {
            result = result.Where(t => t.Owner.UserName == searchParams.UserName);
        }
        

        if (!string.IsNullOrEmpty(searchParams.TitleContains))
        {
            result = result.Where(t =>
                t.Title.Contains(searchParams.TitleContains, StringComparison.OrdinalIgnoreCase));
        }
        
        if (!string.IsNullOrEmpty(searchParams.ContentContains))
        {
            result = result.Where(t =>
                t.Content.Contains(searchParams.ContentContains, StringComparison.OrdinalIgnoreCase));
        }
        
        return Task.FromResult(result);
    }

    public Task<Post?> GetByIdAsync(int id)
    {
        Post? existing = context.Posts.FirstOrDefault(t => t.Id == id);
        return Task.FromResult(existing);
    }
}