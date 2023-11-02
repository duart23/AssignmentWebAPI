using Domain;
using Domain.DTOs;

namespace Application.DAOInterfaces;

public interface IPostDAO
{ 
    Task<Post> CreateAsync(Post post);
    Task<IEnumerable<Post>> GetAsync(SearchPostParameteresDTO searchParameters);
    Task<Post?> GetByIdAsync(int id);
}