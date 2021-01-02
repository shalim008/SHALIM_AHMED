using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<Core.Entities.Identity.Address, AddressDto>().ReverseMap();         

            CreateMap<PostComments, CommentToReturnDto>().ReverseMap();
            CreateMap<Post, PostToReturnDto>()
            .ForMember(d => d.Comments, o => o.MapFrom(s => s.PostComments))
            .ReverseMap();
                             
        }
    }
}