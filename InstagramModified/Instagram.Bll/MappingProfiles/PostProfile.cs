using AutoMapper;
using Instagram.Bll.DTOs;
using Instagram.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Bll.MappingProfiles;

public class PostProfile : Profile
{
    public PostProfile()
    {
        // From smth To smth
        CreateMap<PostCreateDto, Post>();
        CreateMap<Post, PostGetDto>();
        CreateMap<PostUpdateDto, Post>();
    }
}
