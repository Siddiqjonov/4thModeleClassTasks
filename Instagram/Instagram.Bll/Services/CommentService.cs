using Instagram.Bll.DTOs;
using Instagram.Dal.Entities;
using Instagram.Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Instagram.Bll.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository CommentRepository;

    public CommentService(ICommentRepository commentRepository)
    {
        CommentRepository = commentRepository;
    }

    public async Task<long> AddAsync(CommentCreateDto commentCreateDto)
    {
        var comment = new Comment()
        {
            Body = commentCreateDto.Body,
            PostId = commentCreateDto.PostId,
            AccauntId = commentCreateDto.AccauntId,
            ParentCommentId = commentCreateDto.ParentCommentId
        };
        comment.CreatedTime = DateTime.UtcNow;
        var id = await CommentRepository.AddCommentAsync(comment);
        return id;
    }

    public async Task<List<CommentGetDto>> GetAllAsync()
    {
        var comments = await CommentRepository.GetAllComments();
        return comments.Select(c => CovertToDto(c)).ToList();
    }

    private CommentGetDto CovertToDto(Comment comment)
    {
        return new CommentGetDto()
        {
            CommentId = comment.CommentId,
            AccauntId = comment.AccauntId,
            Body = comment.Body,
            PostId = comment.PostId,
            CreatedTime = comment.CreatedTime,
            ParentCommentId = comment.ParentCommentId,
            Replies = comment.Replies?.Select(CovertToDto).ToList() ?? new List<CommentGetDto>() // Recursively map replies
        };
    }

    public async Task<CommentGetDto> GetByIdAsync(long id)
    {
        var comment = await CommentRepository.GetCommentByIdAsync(id);
        return CovertToDto(comment);
    }
}
