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

namespace Instagram.Bll.Services;

public class PostService : IPostService
{
    private readonly IPostRepository PostRepository;
    private readonly IValidator<PostCreateDto> PostCreateDtoValidator;
    private readonly IMapper Mapper;
    public PostService(IPostRepository postRepository,
        IValidator<PostCreateDto> postCreateDtoValidator,
        IMapper mapper)
    {
        PostRepository = postRepository;
        PostCreateDtoValidator = postCreateDtoValidator;
        this.Mapper = mapper;
    }

    public async Task<long> AddAsync(PostCreateDto postCreateDto)
    {
        var validationRes = await PostCreateDtoValidator.ValidateAsync(postCreateDto);
        //return validationRes.IsValid == false ? 
        //    throw new ValidationException($"{string.Join(',', validationRes.Errors)}")
        //    : await PostRepository.AddPostAsync(Mapper.Map<Post>(postCreateDto));

        if (validationRes.IsValid is false)
            throw new ValidationException($"{string.Join(',', validationRes.Errors)}");
        var post = Mapper.Map<Post>(postCreateDto);
        post.CreatedTime = DateTime.UtcNow;
        var id = await PostRepository.AddPostAsync(post);
        return id;
    }

    public async Task DeleteAsync(long id)
    {
        await PostRepository.DeletePostAsync(id);
    }

    public async Task<List<PostGetDto>> GetAllAsync(bool includeComments = false)
    {
        var posts = await PostRepository.GetAllPostsAsync(includeComments);
        var postGetDtos = posts.Select(post => Mapper.Map<PostGetDto>(post)).ToList();
        return postGetDtos;
    }

    public async Task<PostGetDto> GetById(long id)
    {
        var post = await PostRepository.GetPostByIdAsync(id);
        var postGetDto = Mapper.Map<PostGetDto>(post);
        return postGetDto;
    }

    public async Task UpdateAsync(PostUpdateDto postUpdateDto)
    {
        var post = Mapper.Map<Post>(postUpdateDto);
        post.CreatedTime = DateTime.UtcNow;
        await PostRepository.UpdatePostAsync(post);
    }
}
