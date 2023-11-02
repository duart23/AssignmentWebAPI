using Domain;

namespace Application.DAOInterfaces;

public interface IUserDAO
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByUsernameAsync(string userName);
    Task<User?> GetByIdAsync(int id);
    


    
}