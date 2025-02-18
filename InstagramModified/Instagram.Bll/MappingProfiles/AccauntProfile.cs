using AutoMapper;
using Instagram.Bll.DTOs;
using Instagram.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Bll.MappingProfiles;

public class AccauntProfile : Profile
{
    public AccauntProfile()
    {
        CreateMap<AccauntCreateDto, Accaunt>();
        CreateMap<Accaunt, AccauntGetDto>();
        CreateMap<AccauntUpdateDto, Accaunt>();
    }
}
