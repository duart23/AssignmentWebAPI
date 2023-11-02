using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DAOInterfaces;
using Application.LogicInterface;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDAO postDao;
    private readonly IUserDAO userDao;

    public PostLogic(IPostDAO postDao, IUserDAO userDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
    }
    
    public async Task<Post> CreateAsync(PostCreationDTO dto)
    {
        User? user = await userDao.GetByUsernameAsync(dto.UserName);
        if (user == null)
        {
            throw new Exception($"User {dto.UserName} was not found.");
        }

        ValidatePost(dto);
        Post post = new Post(user, dto.Title, dto.Content);
        Post created = await postDao.CreateAsync(post);
        return created;
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParameteresDTO searchParameters)
    {
        return postDao.GetAsync(searchParameters);
    }

    public async Task<PostBasicDTO> GetByIdAsync(int id)
    {
        Post? post = await postDao.GetByIdAsync(id);
        if (post == null)
        {
            throw new Exception($"Post with id {id} not found");
        }
        return new PostBasicDTO(post.Owner.UserName, post.Title, post.Content);
    }
    

    private void ValidatePost(PostCreationDTO dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
        if (string.IsNullOrEmpty(dto.Content)) throw new Exception("Content cannot be empty.");
        // other validation stuff
    }
}