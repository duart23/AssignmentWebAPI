using Application.DAOInterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDAO
{
    
    private readonly PostContext context;

    public PostEfcDao(PostContext context)
    {
        this.context = context;
    }

    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> newPost = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return newPost.Entity;
    }

    public async Task<IEnumerable<Post>> GetAsync(SearchPostParameteresDTO searchParameters)
    {
        IQueryable<Post> query = context.Posts.Include(todo => todo.Owner).AsQueryable();
    
        if (!string.IsNullOrEmpty(searchParameters.UserName))
        {
            // we know username is unique, so just fetch the first
            query = query.Where(todo =>
                todo.Owner.UserName.ToLower().Equals(searchParameters.UserName.ToLower()));
        }
    
        if (!string.IsNullOrEmpty(searchParameters.TitleContains))
        {
            query = query.Where(t =>
                t.Title.ToLower().Contains(searchParameters.TitleContains.ToLower()));
        }

        List<Post> result = await query.ToListAsync();
        return result;
    }

    public async Task<Post?> GetByIdAsync(int id)
    {
        Post? found = await context.Posts
            .Include(post => post.Owner)
            .SingleOrDefaultAsync(post => post.Id == id);
        return found;
    }
    public async Task UpdateAsync(Post todo)
    {
        context.Posts.Update(todo);
        await context.SaveChangesAsync();
    }
}