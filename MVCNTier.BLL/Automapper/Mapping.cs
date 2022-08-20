using AutoMapper;
using MVCNTier.BLL.Models.DTOs;
using MVCNTier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNTier.BLL.Automapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AppUser, RegisterDTO>().ReverseMap().ForAllMembers(x => x.UseDestinationValue());
            CreateMap<Genre, CreateGenreDTO>().ReverseMap().ForAllMembers(x => x.UseDestinationValue());
            CreateMap<Genre, UpdateGenreDTO>().ReverseMap().ForAllMembers(x => x.UseDestinationValue());
        }
    }
}
