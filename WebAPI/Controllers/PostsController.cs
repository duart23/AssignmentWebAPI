using Application.LogicInterface;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class PostsController : ControllerBase
{
    
        private readonly IPostLogic postLogic;

        public PostsController(IPostLogic post)
        {
            this.postLogic = post;
        }
        
        [HttpPost]
        public async Task<ActionResult<Post>> CreateAsync([FromBody]PostCreationDTO dto)
        {
            try
            {
                Post created = await postLogic.CreateAsync(dto);
                return Created($"/posts/{created.Id}", created);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetAsync([FromQuery] string? userName, [FromQuery] int? userId,
            [FromQuery] bool? completedStatus, [FromQuery] string? titleContains)
        {
            try
            {
                SearchPostParameteresDTO parameters = new(userName, titleContains, titleContains);
                var todos = await postLogic.GetAsync(parameters);
                return Ok(todos);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
}