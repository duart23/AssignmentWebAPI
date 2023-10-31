using Domain;
using Domain.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task CreateAsync(PostCreationDTO dto);
    
    Task<ICollection<Post>> GetAsync(
        int? id,
        string userName,
        string titleContains,
        string contentContains
        
    );
}