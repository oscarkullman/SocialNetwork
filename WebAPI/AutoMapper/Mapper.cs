﻿using AutoMapper;
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
            CreateMap<Follow, FollowDto>();
        }
    }
}
