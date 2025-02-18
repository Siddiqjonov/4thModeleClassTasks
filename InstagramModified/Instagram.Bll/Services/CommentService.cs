using AutoMapper;
using FluentValidation;
using Instagram.Bll.DTOs;
using Instagram.Dal.Entities;
using Instagram.Repository.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Instagram.Bll.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository CommentRepository;
    private readonly IValidator<CommentCreateDto> CommentCreateDtoValidator;
    private readonly IMapper Mapper;

    public CommentService(ICommentRepository commentRepository,
        IValidator<CommentCreateDto> commentCreateDtoValidator,
        IMapper mapper)
    {
        CommentRepository = commentRepository;
        CommentCreateDtoValidator = commentCreateDtoValidator;
        Mapper = mapper;
    }
    public async Task<long> AddAsync(CommentCreateDto commentCreateDto)
    {
        var validatorRes = await CommentCreateDtoValidator.ValidateAsync(commentCreateDto);
        if (!validatorRes.IsValid)
        {
            throw new ValidationException($"{string.Join(',', validatorRes.Errors)}");
        }

        //var comment = new Comment()
        //{
        //    Body = commentCreateDto.Body,
        //    PostId = commentCreateDto.PostId,
        //    AccauntId = commentCreateDto.AccauntId,
        //    ParentCommentId = commentCreateDto.ParentCommentId
        //};

        // To something from something 
        var comment = Mapper.Map<Comment>(commentCreateDto);
        comment.CreatedTime = DateTime.UtcNow;

        var id = await CommentRepository.AddCommentAsync(comment);
        return id;
    }
    public async Task<List<CommentGetDto>> GetAllAsync()
    {
        var comments = await CommentRepository.GetAllCommentsAsync();
        var commentGetDtos = comments.Select(c => Mapper.Map<CommentGetDto>(c)).ToList();
        return commentGetDtos;
    }
    //private CommentGetDto CovertToDto(Comment comment)
    //{
    //    return new CommentGetDto()
    //    {
    //        CommentId = comment.CommentId,
    //        AccauntId = comment.AccauntId,
    //        Body = comment.Body,
    //        PostId = comment.PostId,
    //        CreatedTime = comment.CreatedTime,
    //        ParentCommentId = comment.ParentCommentId,
    //        Replies = comment.Replies?.Select(CovertToDto).ToList() ?? new List<CommentGetDto>() // Recursively map replies
    //    };
    //}
    public async Task<CommentGetDto> GetByIdAsync(long id)
    {
        var comment = await CommentRepository.GetCommentByIdAsync(id);
        var commentGetDto = Mapper.Map<CommentGetDto>(comment);
        return commentGetDto;
    }
    public async Task DeleteAsync(long id)
    {
        if (string.IsNullOrWhiteSpace(id.ToString()))
            throw new Exception("id IsNullOrWhiteSpace");
        await CommentRepository.DeleteCommentAsync(id);
    }
    public async Task UpdateAsync(UpdateCommentDto updateCommentDto)
    {
        //var comment = new Comment()
        //{
        //    CommentId = updateCommentDto.CommentId,
        //    Body = updateCommentDto.Body,
        //    PostId = updateCommentDto.PostId,
        //    AccauntId = updateCommentDto.AccauntId,
        //    ParentCommentId = updateCommentDto.ParentCommentId
        //};
        var comment = Mapper.Map<Comment>(updateCommentDto);
        comment.CreatedTime = DateTime.UtcNow;
        await CommentRepository.UpdateCommentAsync(comment);
    }
}
