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
    private ICommentService CommentService;

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
    [HttpDelete("delete")]
    public async Task DeleteComment(long id)
    {
        await CommentService.DeleteAsync(id);
    }
    [HttpPut("update")]
    public async Task UpdateComment(UpdateCommentDto updateCommentDto)
    {
        await CommentService.UpdateAsync(updateCommentDto);
    }
    [HttpGet("getById")]
    public async Task<CommentGetDto> GetCommentById(long id)
    {
        var comment = await CommentService.GetByIdAsync(id);
        return comment;
    }
}
