using Instagram.Bll.DTOs;
using Instagram.Bll.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Server.Controllers;

[Route("api/post")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostService PostService;
    public PostController(IPostService postService)
    {
        PostService = postService;
    }

    [HttpPost("add")]
    public async Task<long> AddPost(PostCreateDto postCreateDto)
    {
        var id = await PostService.AddAsync(postCreateDto);
        return id;
    }

    [HttpGet("getAll")]
    public async Task<List<PostGetDto>> GetAll(bool includeCooments)
    {

        var posts = await PostService.GetAllAsync(includeCooments);
        return posts;
    }
   
    [HttpDelete("delete")]
    public async Task DeletePost(long id)
    {
        await PostService.DeleteAsync(id);
    }
    
    [HttpPut("update")]
    public async Task UpdatePost(PostUpdateDto postUpdateDto)
    {
        await PostService.UpdateAsync(postUpdateDto);
    }
    
    [HttpGet("getById")]
    public async Task<PostGetDto> GetPostById(long id)
    {
        var post = await PostService.GetById(id);
        return post;
    }
}
