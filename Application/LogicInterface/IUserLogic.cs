using Domain;
using Domain.DTOs;

namespace Application.LogicInterface;

public interface IUserLogic
{
    Task<User> CreateAsync(UserCreationDTO userToCreate);
}