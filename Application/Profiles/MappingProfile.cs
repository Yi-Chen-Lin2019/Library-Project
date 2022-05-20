using System;
using Application.Features.BorrowOrder.Dto;
using Application.Features.ItemDescriptor.Dto;
using Application.Features.LibUser.Dto;
using Application.Features.Reservation.Dto;
using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using Domain.AggregateRoots;
using Domain.Entities;
using static Application.Features.LibUser.Dto.LibUserDto;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ItemDescriptor, ItemDescriptorDto>()
                .Include<Article, ArticleDto>()
                .Include<Map, MapDto>()
                .Include<Book, BookDto>()
                .ReverseMap();
            CreateMap<Article, ArticleDto>().ReverseMap();
            CreateMap<Map, MapDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Item, ItemDto>().ReverseMap();

            CreateMap<LibUser, LibUserDto>().ReverseMap();
            CreateMap<MemberType, MemberTypeDto>()
                .ConvertUsingEnumMapping()
                .ReverseMap();
            CreateMap<LibrarianType, LibrarianTypeDto>()
                .ConvertUsingEnumMapping()
                .ReverseMap();
            CreateMap<LibraryCard, LibraryCardDto>().ReverseMap();

            CreateMap<BorrowOrder, BorrowOrderDto>().ReverseMap();
            CreateMap<Reservation, ReservationDto>().ReverseMap();
        }
    }
}
