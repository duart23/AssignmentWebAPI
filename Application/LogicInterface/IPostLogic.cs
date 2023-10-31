using Domain.DTOs;
using Domain;
namespace Application.LogicInterface;

public interface IPostLogic
{
        Task<Post> CreateAsync(PostCreationDTO dto);
        Task<IEnumerable<Post>> GetAsync(SearchPostParameteresDTO searchParameters);
}