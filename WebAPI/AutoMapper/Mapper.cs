using AutoMapper;
using SocialNetwork.Classes;
using SocialNetwork.Classes.Message;
using SocialNetwork.Classes.Post;
using SocialNetwork.Classes.User;
using WebAPI.DTO;
using WebAPI.Entities;
using WebAPI.Models;

namespace WebAPI.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, UserDto>();
            CreateMap<Post, PostDto>();
            CreateMap<StatusCodeHandler<Post>, StatusCodeHandler<PostDto>>();
            CreateMap<Follow, FollowDto>();
            CreateMap<Message, MessageDto>();
        }
    }
}
