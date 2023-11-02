using System.ComponentModel.DataAnnotations;
using Application.DAOInterfaces;
using Domain;
using Domain.DTOs;

namespace WebAPI.Services;

public class AuthService : IAuthService
{

    private readonly IUserDAO UserDao;

    public AuthService(IUserDAO userDao)
    {
        this.UserDao = userDao;
    }


    public Task RegisterUser(User user)
    {
        if (string.IsNullOrEmpty(user.UserName))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.password))
        {
            throw new ValidationException("Password cannot be null");
        }
        return Task.CompletedTask;
    }

    public Task<User> ValidateUser(string username, string password)
    {
       Task <User?> existingUser =UserDao.GetByUsernameAsync(username);


        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Result.password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

       return existingUser;

    }

    
    
}