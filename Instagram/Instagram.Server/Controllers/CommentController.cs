using Azure.Core.GeoJson;
using Instagram.Bll.DTOs;
using Instagram.Bll.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Server.Controllers;

[Route("api/comment")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentService CommentService;

    public CommentController(ICommentService commentService)
    {
        CommentService = commentService;
    }
    [HttpPost("add")]
    public async Task<long> AddComment(CommentCreateDto commentCreateDto)
    {
        return await CommentService.AddAsync(commentCreateDto);
    }
    [HttpGet("getAll")]
    public async Task<List<CommentGetDto>> GetAllComment()
    {
        return await CommentService.GetAllAsync();
    }
}
